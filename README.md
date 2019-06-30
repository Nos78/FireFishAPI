# FireFishAPI
Project files; producing a simple web API from a given set of dbo files, with a jquery web frontend


# The instructions are as follows:
==================================
1. clone the repository at:
git clone https://github.com/Nos78/FireFishAPI

2. Restore the backup dbo to SQLEXPRESS running on localhost.

3. Edit the web.config file at line 7:

Replace the <connectionString> Data Source "DESKTOP-O8RE023\SQLEXPRESS" with the name of your own SQL server information.

4. After cloning the repository, a bug in Visual Studio package manager produces an error...:
Could not find ... bin\roslyn\csc.exe
if you try to run the solution without first running the command:
Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r
in the Package-Console-Manager (Tools->NuGet Package Manager->Package-Manager-Console).

5. Open the FireFishAPI solution and run the Web API (F5).

The browser should open, displaying the website UI part of the solution (Task 2).

http://localhost:50178/

(the random port will probably be different for you).

Task 2 Website UI Solution: http://localhost:50178/index.html
- As the API and UI are both running on localhost, I created the single page web front-end within the same project as the api, and in a real world environment, this could be seperated out into a seperate web project.

Task 1: Web API can be found at
http://localhost:50178/api/... (see below)

The following addresses specify the interface:

The API urls (Task 1) are:

GET: api/candidate
GET: api/candidate/5
POST: api/candidate
PUT: api/candidate/5
DELETE: api/candidate/5

GET: api/Skill
GET: api/Skill/5
POST: api/Skill
PUT: api/Skill/5
DELETE: api/Skill/5

GET: api/CandidateSkill/5
POST: api/CandidateSkill
DELETE: api/CandidateSkill/5


Note:

After downloading a clean copy of the solution from github, I encountered the error:
Could not find a part of the path … bin\roslyn\csc.exe

I resolved this by entering in the NuGet Package-Console-Manager:
Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r
