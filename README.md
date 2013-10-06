# MarkdownOut

I created this because I needed to create a bunch of Markdown-formatted files through code and was tired of manually typing out the syntax. MarkdownOut provides a simple wrapper class around System.IO.StreamWriter that can add Markdown syntax to its output.

*Disclaimer: Markdown syntax is defined is a variety of different ways. Feel free to adjust MarkdownOut to comply with your syntax definition of interest.*

## Styles and Formats

MarkdownOut can apply Markdown *styles* and Markdown *formats* to text.

A style is explicitly terminated and can be applied to sub-strings of a line of text. For example, the italic style is opened with the \* character and terminated with the \* character. MarkdownOut can apply the following styles:

- *Italic*

- **Bold**

- ***Bold and italic***

- `Code`

- ~~Strike-through~~

A format is not explicitly terminated and is applied to an entire line or block of text. For example, the quote format is opened with the "> " string and is not terminated until a Markdown paragraph break (two newlines). MarkdownOut can apply the following formats:

- Heading 1

- Heading 2

- Heading 3

- Heading 4

- Heading 5

- Heading 6

- Quote

- Unordered list item

- Ordered list item

## Writing Markdown to a File

To write Markdown-formatted text to a file, just create an instance of the MdWriter class, a bare bones wrapper around System.IO.StreamWriter that provides the expected Write, WriteLine, etc. methods. All write methods allow you supply a style and format to apply to the output text, and additional methods are provided for writing indented sub-lists.

## Styling and Formatting Strings

If you don't need to write text to a file, the MdText class provides static methods for styling and formatting strings with Markdown syntax.