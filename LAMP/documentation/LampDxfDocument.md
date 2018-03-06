# LampDxfDocument
A way to open, read, alter and write dxf files
## Constructor
- `New()`
	- Creates an empty DxfDocument
- `New(dxf as DxfDocument)`
	- Creates from an exisitng DxfDocument (NOT LampDxfDocument). Shouldn't really need to be used
- `
## Methods (Shared)
- `LoadFromString(dxf as string) -> LampDxfDocument`
	- Creates a dxf document from a string, formatted as a dxf
- `LoadFromFile(filePath as string) -> LampDxfDocument`
	- Loads a dxf document from the filepath
## Methods (Instance)
- `ToDxfString() -> String
	- Converts to a string encoded in DXF format
- `ToImage(center As PointF, width As Integer, Height as Integer) -> Image`
	- Renders the drawing, with center at `Center`, and width and height as specified
- `ToImage()`
	- Renders the entire drawing. Can create VERY big pictures
- `AddLine(x1 As Double, y1 As Double, x2 As Double, y2 As Double)`
	- Adds a new line to the drawing
- `AddLine(start As Vector3, [end] As Vector3)`
	- Adds a new line
- `AddCircle(centerX As Double, centerY As Double, radius As Double)`
	- Adds a new circle
- `AddCircle(centre As Point3, radius As Double)`
	- Adds a new circle
- `AddArc(centerX As Integer, centerY As Integer, radius As Double, startAngle As Double, endAngle As Double)`
	- Adds a new arc. angle in degrees
## Variables
- 
