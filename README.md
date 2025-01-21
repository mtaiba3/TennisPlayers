Tennis Palyer project:

This project is a small .Net 8 project using CQRS architecture for retrieving tennis players informations and stats.
The project is divided into 4 main projects and a unit test project:
  *) TennisPlayers Project: The main project and it contains the controllers for retrieving players, retrieving a plaer by Id and retrieving statistics.
  *) TennisPlapyers.Application: The user stories project which contains all the handlers and query + the logic behind the methods and the formatting of the data.
  *) TennisPlayers.Domain: An intermediary project in which we have the dto and the interface of the repository.
  *) TennisPlayers.Infrastrucutre: The main repository to get the data from the specified file (headtohead.json).
  *) TennisPlayers.UnitTests: The unit tests project in xUnit.

to launch the project you need to set TennisPlayers Project as a startup Project and the click launch (https), the localhost interface should be like this
![image](https://github.com/user-attachments/assets/0a345d71-eec7-4a1c-96d3-4222571920b9)

To launch the unit test you just go to the testexplorer window and hit launch all
