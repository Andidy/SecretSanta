# SecretSanta
A simple text based C# Secret Santa generator with 'family' filtering

This project was built using the .NET Framework 4.6.1 in Visual Studio

Usage: 
1. Build/Compile it.
2. Inside the working directory, ex SecretSanta/bin/Debug, or simply the file location of the .exe, create a file called input.txt
3. Within that file list the names of participants in the following format: name family_id
   
   To clarify, each line should have a name, followed by 1 space, then another string used to denote what 'family' each person is apart of, if there isn't a need for family identifiers give each person a unique family_id.
4. Run the built .exe or other run file
5. An output file will appear in the working directory called "output.txt" with each line saying who each person's secret santa is.
