# .NET Core Architecture Test

## Introduction
This is an architecture test for **.NET Core** ecosystem.    
The author has not any experience on **.NET Core** application development so it possibly will add quite objectivity.    
It pretends to test next aspect list in order to compare whit other options.    

- [Linux integration](#linux-integration)
- [Virtual environment integration (sdk level)](#virtual-environment-integration-sdk-level)
- [IDE integration](#ide-integration)
- [Isolation](#isolation-in-terms-of-the-twelve-factors-app) (in terms of [**The Twelve Factors App**](https://12factor.net/))
- [Resilience](#resilience)
- [Hot-reload / AOT](#hot-reload-aot)
- [Efficiency (time to deploy, time to response, stress)](#efficiency-time-to-deploy-time-to-response-stress)
- [Compatibility with other technologies](#compatibility-with-other-technologies)
- [Maintainability / reusability](#maintainability--reusability)
- [Monitoring (resource consumption, health, readiness)](#monitoring-resource-consumption-health-readiness)
- [Traceability](#traceability)
- [Logging](#logging)

### Setup
We are going to work on Linux OS.    
Before you get started a few things needs to be set up.    

### IDE
It can be used [**Visual Studio Code**](https://code.visualstudio.com/). It has a `c#` extension that allows execute and debug our application. Syntax highlighting and code completion as well as ‘go to declaration’ feature.    

### DB
It is convenient to use docker because we can switch from one project to other and shut down all we dont need easily.    
``` sh
docker run --name arq-mysql -e MYSQL_ROOT_PASSWORD=some-pass -p 3306:3306 -d mysql
# The following command may need to be run multiple times until the server is fully available
docker exec -it arq-mysql mysql -u root -p #enter some-pass
```

Once on mysql client
``` sql
CREATE DATABASE dbnetcore;
CREATE USER 'netcoreuser'@'%' IDENTIFIED BY 'netcorepass';
GRANT ALL PRIVILEGES ON dbnetcore. * TO 'netcoreuser'@'%';
FLUSH PRIVILEGES;
```
It is a good practice to not use root credentials, because application will not get this permission level on production environment.   

#### Linux integration
It is relatively simple to install the **.NET Core** SDK on linux. You need just to download the version to want to use, place it on some directory (`/opt` preferably) and add directory to $PATH via environment variables.

#### Virtual environment integration (sdk level)
In Windows apparently it is automatically managed for IDE. It can be installed all the versions of SDK and the IDE will use which is specified in 'global.json'
There is no documentation about a similar behaviour on Linux. But it should be not difficult to emulate on this OS. It is possible to install all SDK versions assets in "opt" directory and then set whichever the application requires via environment variables before run application. It surely requires a bash script but this doesn't seem like a problem and provides more control over application

# IDE integration
[**Visual studio C# extension**](https://code.visualstudio.com/docs/languages/csharp#_installing-c35-support) is a complete toolkit that provides all necesary feature to develop a system un **.NET Core** but aparently there is a possible issue with **.NET Core** itself: 
Searching on the web and even consulting a 5 years experience developer we come to the conclusion that it is not possible to navigate external source code during debugging. It is posible link a librery to a directory in the local filesystem but it is necesary some lucky to make it work
For example, if it were necessary to step out in a Controller code while it would be expected to jump into the framework implementation, it would instead exit the debug context without continuing navigation. 

#### Isolation (in terms of [**The Twelve Factors App**](https://12factor.net/))    
work in progress    

#### Resilience
work in progress    

#### Hot-reload / AOT    
work in progress    

#### Efficiency (time to deploy, time to response, stress)    
work in progress    

#### Compatibility with other technologies    
work in progress    

#### Maintainability / reusability     
work in progress    

#### Monitoring (resource consumption, health, readiness)    
work in progress    

#### Traceability    
work in progress    

#### Logging    
work in progress    
