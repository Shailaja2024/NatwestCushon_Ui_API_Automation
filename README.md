# NatwestCushon_UI_API_Automation_Test

## Description
This is a test automation project created for the interview assessment. The project uses **Reqnroll ** for Behavior-Driven Development (BDD), **Selenium** for UI automation, Nunit, and **RestSharp** for API testing. Also, this project supports **cross-browser testing** using **Selenium WebDriver** for multiple browsers.
## Tools & Technologies Used 

- **Selenium**: For automating UI interactions across multiple browsers. - **NUnit**: For test automation framework. - **Reqnroll**: For BDD-style tests and feature files. - **RestSharp**: For performing API requests and assertions. - **ExtentReports**: For generating detailed HTML test reports with screenshots. - **WebDriverHelpers**: For configuring WebDriver instances (Chrome, Gecko, Edge). - **ConfigManager**: For reading and managing configuration data from `runsettings.json`.
## Installation and Setup

### Prerequisites
Before setting up the project, ensure you have the following installed:
- **Visual Studio 2022** (with .NET 9.0 SDK and NUnit support)
- **Reqnroll Extension** for Visual Studio

You will also need to install the following NuGet packages:
 - Selenium WebDriver 
- Selenium Support –
- Reqnroll.NUnit
 - Reqnroll.SpecFlow Compatibility 
- NUnit3TestAdapter 
- RestSharp - AventStack.ExtentReports
- WebDrivers(Chrome, Gecko and Edge  WebDrivers for Selenium)
### Setup Instructions
1. **Install Visual Studio 2022**:
   - Download and install Visual Studio 2022 if you haven't already. Select the **ASP.NET** workloads  during installation.
2. **Create a New Project**:
   - Open Visual Studio 2022.
   - Go to **File** > **New** > **Project**.
   - Choose **Reqnroll Test Project** templates using **.Net 9**  framework and ** Nunit** Test Framework and create your project.
   - Visual Studio will generate the default folder structure for the project.
## Features & Implementation
### 1. **UI Automation**
 - **Feature Files**: Located in the `Features` folder.
 - **Step Definitions**: Implemented in separate `.cs` files.
 - **Page Object Model**: Page objects like `LoginPage.cs`, `HomePage.cs` encapsulate the UI logic.
 - - **Reusable Methods**: Methods are centralized in the `ReusableMethods.cs` class to avoid duplication.
 - **Cross-Browser Testing**: Configured for Chrome, Gecko (Firefox), and Edge using `WebDriverHelpers.cs`.
 - **Test Reporting**: ExtentReports generates HTML reports with screenshots in the `TestResults` folder.
 ### 2. **API Testing**
 - **Feature Files**: Located in the `APITest` folder. 
- **API Testing**: API tests are implemented using RestSharp in `ApiTest.cs`.
 - **Step Definitions**: Separate step definitions for API tests. 
### 3. **Configuration and Data Management**
 - **runsettings.json**: Holds the test configurations and data sets. 
- **ConfigManager.cs**: Reads configuration data from the JSON file during test execution. 
### 4. **Hooks and Reporting** 
- **Hooks**: `TestHooks.cs` contains Before and After scenario hooks to handle initialization and clean-up. 
- **ExtentReports Integration**: HTML reports and screenshots are generated after each test run, located in the `TestResults` folder.
###  Test Execution in Visual Studio
1. Open the project in Visual Studio 2022.
2. Go to **Test Explorer** by navigating to **Test** > **Windows** > **Test Explorer**.
3. In the **Test Explorer** window, click **Run All** to execute all tests or select individual tests to run.
### Test Reports
Test results are shown in the **Test Explorer** window. Additionally, detailed reports can be found in the `TestResults` folder after execution.

### **Commit and Push to GitHub**:
   - After completing the implementation, create a new repository on GitHub.
   - Open **Git Bash** or a terminal in your project folder.
   - Run the following commands to push your project to GitHub:
         git init
         git add .
        git commit -m "Initial commit with automation tests"
         git remote add origin https://github.com/yourusername/your-repo.git
         git push -u origin master


## Troubleshooting Guide

### 1. WebDriver Issues
- **Issue**: WebDriver not found or mismatched versions.
- **Solution**: Ensure the correct version of WebDriver is installed (e.g., ChromeDriver) and matches the version of your browser. Download the appropriate version from [WebDriver downloads](https://www.selenium.dev/downloads/).

### 2. Test Failures
- **Issue**: Tests failing without clear error messages.
- **Solution**: Check the **Test Explorer** window for detailed error messages or exceptions. Look for specific failures that can guide you in resolving the issue.

### 3. Missing Dependencies
- **Issue**: "Missing NuGet packages" or "Dependencies not restored".
- **Solution**: Run **NuGet Restore** from Visual Studio to ensure all dependencies are correctly installed.

### 4. Environment Variables
- **Issue**: API tests failing due to incorrect URLs.
- **Solution**: Verify that the correct environment variables are set for API URLs in the configuration files (`runsettings.json`) or through environment variables.


