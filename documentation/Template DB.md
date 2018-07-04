# Template Database
A database of all the templates in the file
## Constructor
- `New(name as String)`
	- Creates a TemplateDB with the given name. Calls createTable() 

## Methods (Instance)
- createTable()
	- Creates a table in the DB with following SQL
								  CREATE TABLE if not exists test (
                                  Auto_ID INTEGER PRIMARY KEY AUTOINCREMENT, 
                                  DXF Text Not NULL,
                                  Tag Text DEFAULT 'None',
                                  material Text Not NULL,
                                  length Int Not NULL,
                                  Height Int Not NULL,
                                  thickness Int Not NULL,
                                  creatorName Text Not NULL,
                                  creator_ID Int Not NULL,
                                  approverName Text DEFAULT 'NONE',
                                  approver_ID Int Default 0,
                                  complete Int DEFAULT 0);
- removeEntry(id as INTEGER)
	- removes an entry from the DB based on given ID
- addDebugEntry(DXF As String, tag As String, material As String, length As Integer, height As Integer, thickness As Integer, creatorName As String, creator_ID As Integer)
	- Adds an entry to the DB with given variables. Debug purposes.
- addEntry(lamp as LampTemplate)
	- Adds an entry to the DB with given LampTemplate
- selectEntry(id as INTEGER)
	- Returns a lamp template from database

## Variable
- `PublicVarName`-> VariableType
	- Description