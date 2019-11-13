using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;


namespace Cognizant_automation
{
    class Program
    {
        static void Main(string[] args)
        {
            //Navigate to the page
            var driver = new ChromeDriver("./");
            driver.Url = "http://hpadevtest.azurewebsites.net/";

            //STEP 1
            driver.FindElementByXPath("//*[@id=\"Box1\"]").Click();
            //Handling Alert
            driver.SwitchTo().Alert().Accept();
            Console.WriteLine("STEP 1 COMPLETE");

            //STEP 2
            var step_2 = driver.FindElementByXPath("//*[@id=\"Box3\"]");
            step_2.Click();
            step_2.SendKeys(Keys.Tab);
            //Handling Alert
            driver.SwitchTo().Alert().Accept();
            Console.WriteLine("STEP 2 COMPLETE");

            //STEP 3
            //Pull the value to select from the instructions
            var step_3_instruction = driver.FindElementByXPath("//*[@id=\"optionVal\"]").Text;
            //Select the option that matches that instruction value
            driver.FindElementByXPath($"//*[@id=\"Box2\"]/input[{step_3_instruction}]").Click();
            //Handling Alert
            driver.SwitchTo().Alert().Accept();
            Console.WriteLine("STEP 3 COMPLETE");

            //STEP 4
            //Pull the value to select from the instructions
            var step_4_instruction = driver.FindElementByXPath("//*[@id=\"selectionVal\"]").Text;
            //Get the select element
            var element = driver.FindElementByXPath("//*[@id=\"BoxParagraph4\"]/select");
            //Convert into a SelectElement
            SelectElement select = new SelectElement(element);
            //Select the option that matches the instruction
            select.SelectByText($"{step_4_instruction}");
            //Handling Alert
            driver.SwitchTo().Alert().Accept();
            Console.WriteLine("STEP 4 COMPLETE");

            //STEP 5
            //Loop through all 10 of the input fields and insert their placeholder as their input value
            for (int i = 1; i < 10; i++)
            {
                var field = driver.FindElementByXPath($"/html/body/div[5]/center/div/div/div[1]/center/table/tbody/tr[{i}]/td/input");
                var placeholder = field.GetAttribute("placeholder");
                field.SendKeys(placeholder);
            }
            //Click submit
            driver.FindElementByXPath($"//*[@id=\"FormTable\"]/tbody/tr[10]/td/center/button").Click();
            //Handling Alert
            driver.SwitchTo().Alert().Accept();
            Console.WriteLine("STEP 5 COMPLETE");

            //STEP 6
            var line5_value = driver.FindElementByXPath("//*[@id=\"formResult\"]").GetAttribute("value");
            //Essentially a wait-for-this-element-to-have-a-text-value loop
            while (line5_value == null)
            {
                line5_value = driver.FindElementByXPath("//*[@id=\"formResult\"]").Text;
            }
            //Get the line number to insert the value from above, clear its contents, insert number
            var lineNumber = driver.FindElementByXPath("//*[@id=\"lineNum\"]").Text;
            var inputField = driver.FindElementByXPath($"//*[@id=\"inputTable\"]/tbody/tr[{lineNumber}]/td[2]/input");
            inputField.Clear();
            inputField.SendKeys(line5_value);
            inputField.SendKeys(Keys.Enter);
            driver.SwitchTo().Alert().Accept();
            Console.WriteLine("STEP 6 COMPLETE");

            //STEP 7
            driver.FindElementByXPath("//*[@id=\"Box7\"]").Click();
            //Wait for the Alert - I didn't encounter any waits longer than 10 seconds
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.AlertIsPresent());
            driver.SwitchTo().Alert().Accept();
            Console.WriteLine("STEP 7 COMPLETE");

            //STEP 8
            driver.FindElementByXPath("//*[@id=\"Box8\"]").Click();
            //Wait for the Alert - I didn't encounter any waits longer than 10 seconds
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.AlertIsPresent());
            driver.SwitchTo().Alert().Accept();
            Console.WriteLine("STEP 8 COMPLETE");

            //STEP 9
            driver.FindElementByXPath("//*[@id=\"Box9\"]").Click();
            //Wait for the Alert - I didn't encounter any waits longer than 10 seconds
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.AlertIsPresent());
            driver.SwitchTo().Alert().Accept();
            Console.WriteLine("STEP 9 COMPLETE");

            //STEP 10
            driver.FindElementByXPath("//*[@id=\"Box10\"]").Click();
            //Wait for the Alert - I didn't encounter any waits longer than 10 seconds
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.AlertIsPresent());
            driver.SwitchTo().Alert().Accept();
            Console.WriteLine("STEP 10 COMPLETE");
        }
    }
}
