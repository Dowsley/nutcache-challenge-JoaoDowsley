# PeopleApi
## Required Requirements
- [x] Define and implement a people registration API with the following data (* = required);
  - Name (text) * 
    - String with no limitations
  - Birth Date * 
    - (dd/mm/yyyy) with date picker
  - Gender (dropdown) * 
    - DROPDOWN WITH ENUMS: Male, Female, Other
  - Email *
    - String validated by regex
  - CPF *
    - String validated by regex, including cpf without dashes and/or dots. 
  - Start Date (MM/YYYY) * 
    - String validated by regex
  - Team 
    - DROPDOWN WITH ENUMS: Mobile, Frontend, Backend. (nullable)
- [x] Define and implement a listing API for all employees already registered; 
- [x] Define and implement an API to delete a previously registered employee; 
- [x] Define and implement an API to edit a previously registered employee; 
- [x] Main page with registered employees grid with edit and disable options for each row 
- [x] The grid must display Name, Email, Start Date and Team for each employee; 
- [x] Popup to register an employee. 
- [x] Popup to edit a registered employee. 
- [x] Popup to confirm disable employee action.



## Desirable (optional) Requirements
- [x] In addition to the code, also should be delivered by a git repository, with the following 
name convention: nutcache-challenge-yourFirstAndLastNameWithoutSpaces 
- [ ] A document detailing your technical solution and the instructions to run the 
application must be in the README.md of the root folder of your repository. 
- [ ] The Web front-end using Angular, Vue, React or any other framework 
- [x] Implement unit tests for all the features 
- [ ] Appropriate use of SOLID, ACID and design patterns (use when necessary), according to 
the platform of your choice