# LampTemplate
A Lamptemplate stores the original item to be cut, with options to duplicate
the item several times based off the insertion point system
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
- `Template -> LampDxfDocument`
  - Stores the actual
