# InteractiveSpeechApplication

##Assumption 1

In "P_RememberInterviewers " scenario, I don't know what will happen after user answered  
the question "[P_ShouldHire] And you think we should hire you? ".
I saw the previous branches could go to "Transfer" section, but I have no idea about this branch.
So it brings two possible options:
1) It goes to "Transfer" section as well.
2) The current session will go directly to end from this point, which means the session will go to end call section.

Since everyone is busy and my question might not really matter to the key point of the test, I chose
option 1 because it will perform more functionalities for testing purpose.

##Assumption 2

The path for generate `log` file is under `AppDomain.CurrentDomain.BaseDirectory`. I manually copied the file to `Log` folder
for reviewing convenience.

Thank you!
