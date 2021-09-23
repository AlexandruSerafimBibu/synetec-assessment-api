## Serafim's notes

I refactored the code to the best of my abilities. For UnitTesting I used the NUnit framework. If it dosn't work, try installing "NUnit 3 Test Adapter" visual studio extension.
First of all I started implementing two separate services (One for Employees and one for BonusPool) and inject them in the controller. I also created two controllers. One for Employees and one for the BonusPool. Both of them  return either Ok or BadRequest.

I created a folder with Utils.cs that contains the Calculator logic. Noticing the pdf had used decimal numbers I changed most properties and variables involved in calculating the bonus to decimal.

I used AutoMapper package to map DbEntities to their specific Dtos.

I changed some namespaces and renamed the api project.

I tried using async await where it's needed, except the UnitTesting classes. I'm not too familiar with UnitTesting at this point in time.

My coding style is in a continuous learning curve. I try writing clean code, easy to understand and adhering to the SOLID principles.

# Synetec Basic .Net API assessement

This is Synetec's basic API developer assessment.

If you are reading this, you most probably have been asked to complete this assessment as part of Synetec's interview process.

In this repository, you will find the base project and instructions on what to do with them. 

## How to complete this test

Please follow the instructions in the Instructions.pdf, found in this repository

Please explain the work that you did or any challenges that you faced, either by comments in code or in an email. 
In case the requirements are not met or they are not finished please explain the reasoning behind that.

## How to submit your completed test

To sumbit your test, please 
1. Fork this repository
2. Complete the test as per the instructions PDF 
3. Commit your changes to your (forked) repo 
4. Send us an http link to your repo that contains the completed test 

**This repo is Read-Only!!** So please don't try to open a pull request
