# LampTemplate
A Lamp template stores the original item to be cut, with options to duplicate
the item several times based off the insertion point system
## How to use
Construct a new template using `Dim foo as New LampTempate()` or `Dim foo as New LampTemplate(dxf)`
, where dxf is a LampDxfDocument. By default, 0,0 will be added as an insertion point.
New insertion points can be added by using
`foo.InsertionLocations(New LampDxfInsertLocation)`

## Constructor
- `New(start As LampDxfTemplate=Nothing)`
  - Creates a new Template w/ the drawing. Empty for new empty drawing
## Methods (Shared)
- `Load(filepath as String) -> LampTemplate`
  - Loads a LampTemplate (.spf) file from the file path given
- `Deserialize(json as String) -> LampTemplate`
  - Converts a JSON string to a lamptemplate. A (.spf) file is essentially a file
  that contains this string

## Methods (Instance)
- `Serialize(formatting As Formatting=None) -> string`
  - Converts this template into a JSON string
- `Save(filepath as String)`
  - Saves the template as a .spf file to the filepath given


## Variables
- `Guid -> String` <Serialized>
  - A random unique identifier for the template
- `Name -> String` <Serialized>
  - The name of the template shown to the user
- `ShortDescription -> String` <Serialized>
  - A short description of what the template is for etc
- `LongDescription -> String` <Serialized>
  - A longer description of what the template is used for
- `CompletedDrawing -> LampDxfDocument`
  - The completed drawing that needs to be sent to the laser cutter. This is the template tiled/rotated around so that it fits on the laser cutting bed
- `BaseDrawing -> LampTemplate` <Serialized>
  - The template of the template, which is tiled around to create CompletedDrawing
- `Tags -> List(Of String)` <Serialized>
  - A list of user create-able tags. Max of 5
- `Material -> String` <Serialized>
  - The material that the template should be cut on. e.g. plywood, acrylic etc
- `Height -> Double`
  - The expected height of the base template
- `Length -> Double`
  - The expected width of the base template
- `MaterialThickness -> Double` <Serialized>
  - The recommended thickness of material to cut
- `SubmitDate -> Date?` <Serialized>
  - The time/date it is submitted. Nothing if it has not been submitted yet
- `DynamicTextList -> IList(Of DynamicText)` <Serialized>
  - Stores the (x,y) positions of where the text must be inserted the base drawing.
- `InsertionLocations -> IList(Of LampDxfInsertLocation)` <Serialized>
  - Stores were templates must be inserted to create the CompletedDrawing
- `IsComplete -> Boolean` <Serialized>
  - If the file is in a complete state, that is insertion points are specified and ready to submit.
- `CreatorName -> String` <Serialized>
  - Full name of creator
- `CreatorId -> String` <Serialized>
  - the guid of the user who created it
- `ApproverName -> String` <Serialized>
  - The name of the person who approves the templates
- `ApproverId -> String` <Serialized>
  - GUID of the approver
- `PreviewImages -> List(Of Image)` <Serialized>
  - preview images
