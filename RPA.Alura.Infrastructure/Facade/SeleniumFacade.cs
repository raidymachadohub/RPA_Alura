using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RPA.Alura.Domain.Model;
using RPA.Alura.Infrastructure.Facade.Interfaces;
using RPA.Alura.Shared.FlowControl.Enum;
using RPA.Alura.Shared.FlowControl.Model;

namespace RPA.Alura.Infrastructure.Facade;

public class SeleniumFacade : ISeleniumFacade
{   
    public Result<IEnumerable<Courses>> CaptureData(Routine routine)
    {
        try
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.alura.com.br/");

            IWebElement ele = driver.FindElement(By.Name("query"));
            ele.SendKeys(routine.TitleSearch);
            ele.Submit();

            //5Seconds Delay
            Thread.Sleep(5000);

            //<div ul>
            var coursesUl = GetListCoursesUl(driver);

            //<div li>
            if (coursesUl == null)
                return Result.Fail<IEnumerable<Courses>>(new Error(ErrorType.NotFound, ""));

            var coursesLi = GetCoursesLi(coursesUl.FirstOrDefault()!);

            // Capturar dadados
            var courses = ExtractData(coursesLi, routine: routine);

            driver.Close();
            
            return Result<Courses>.Ok(courses);
        }
        catch (Exception e)
        {
            return Result.Fail<IEnumerable<Courses>>(new Error(ErrorType.Business, "Erro na extração de dados. Ex: " + e.Message));
        }
    }

    private static IEnumerable<Courses> ExtractData(IEnumerable<IWebElement> coursesLi, Routine routine)
    {
        var listCourse = new List<Courses>();
        foreach (var courseLi in coursesLi)
        {
            var title = courseLi.FindElement(By.ClassName("busca-resultado-nome")).Text;
            var description = courseLi.FindElement(By.ClassName("busca-resultado-descricao")).Text;
            
            //Novo Driver
            var linkCourse = courseLi.FindElement(By.ClassName("busca-resultado-link")).GetAttribute("href");
            IWebDriver driverL = new ChromeDriver();
            driverL.Navigate().GoToUrl(linkCourse);

            //5Seconds Delay
            Thread.Sleep(5000);

            if (IsElementPresent(By.ClassName("subtitle"), driverL))
            {
                if (driverL.FindElement(By.ClassName("subtitle")).Text.Contains("Faça seu login e boa aula!"))
                {
                    driverL.Close();
                }
            }
            else
            {
                var teacher = "";
                if (IsElementPresent(By.ClassName("instructor-title--name"), driverL))
                    teacher = driverL.FindElement(By.ClassName("instructor-title--name")).Text;

                if (IsElementPresent(By.ClassName("formacao-instrutores-lista"), driverL))
                {
                    var teachers = driverL.FindElement(By.ClassName("formacao-instrutores-lista"));
                    teacher = string.Join(",", teachers.FindElements(By.TagName("li"))
                        .Select(x => x.FindElement(By.ClassName("formacao-instrutor-nome")).Text));
                }

                var workLoad = "0";
                if (IsElementPresent(By.ClassName("courseInfo-card-wrapper-infos"), driverL))
                    workLoad = driverL.FindElement(By.ClassName("courseInfo-card-wrapper-infos")).Text;

                if (IsElementPresent(By.ClassName("formacao__info-destaque"), driverL))
                    workLoad = driverL.FindElement(By.ClassName("formacao__info-destaque")).Text;

                var course = new Courses(title: title,
                    teacher: teacher,
                    workLoad: GetNumbers(workLoad),
                    description: description,
                    routine: routine);

                listCourse.Add(course);

                driverL.Close();
            }
        }

        return listCourse;
    }

    private static ICollection<IWebElement> GetListCoursesUl(IWebDriver driver)
        => driver.FindElements(By.ClassName("paginacao-pagina"));

    private static ICollection<IWebElement> GetCoursesLi(IWebElement listCoursesUl)
        => listCoursesUl.FindElements(By.TagName("li"));

    private static double GetNumbers(string input)
        => Convert.ToDouble(new string(input.Where(c => char.IsDigit(c)).ToArray()));

    private static bool IsElementPresent(By by, IWebDriver driver)
    {
        try
        {
            driver.FindElement(by);
            return true;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }
}