# directory-tracker

Supported only on Windows

DirWatcher is long running background time looped scheduled task which stores results in database. This has two main components:

scheduled backuground task
Sqlite database

Tech stack:
1. C#, .Net 7.0
2. Entity Framework Core
3. Sqlite database

Highlevel Design
![image](https://github.com/pallaviaayasya/directory-tracker/assets/75925773/f4a22478-2186-4adf-81cb-37abaff64a75)


File Watcher is responsible for:

Listning for registered events on the configured watch directory.
Record the event in the file_event database.

Database Schema

Table: tracking_details
<img width="218" alt="Screenshot 2024-03-25 at 12 51 36 PM" src="https://github.com/pallaviaayasya/directory-tracker/assets/75925773/6a2b0e42-4996-46c2-b87a-4241404d86d7">


