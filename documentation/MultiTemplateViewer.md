# MultiTemplateViewer
Shows multiple templates in 1 control. Customizable rows, columns contents. Acts like a big table
# How to use
First build the project, then drag the MultiTemplateViewer control onto a form.

Set `ColumnCount` or `RowCount` in the designer to change the number of rows etc in the MultiTemplateViewer

Use the function `SetTemplateToPosition` to show a template at that location.

## Constructor
- `New()`
	- Creates a new MultiTemplateViewer
## Methods (Shared)
- None
## Methods (Instance)
- `GetTemplateFromPosition(col as int, row as int) -> LampTemplate`
  - Gets the template from the position given. Returns Nothing if there is no template
- `GetControlFromPosition(col as int, row as int) -> FileDisplay`
	- Gets a `FileDisplay` from the position given.
- `SetTemplateToPosition(col as int, row as int, template as LampTemplate)`
  - Puts the template in the position given. Throws an error if it is out of bounds.
## Variable
- `ColumnCount`-> Integer
  - Controls the number of columns in the table
- `RowCount` -> Integer
  - Controls the number of rows in the table
