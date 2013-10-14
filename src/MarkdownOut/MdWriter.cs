using System;
using System.IO;

namespace MarkdownOut {

    /// <summary>
    /// A wrapper around <see cref="StreamWriter"/> used to write Markdown text to a file.
    /// </summary>
    public class MdWriter : IDisposable {

        private StreamWriter stream;

        /// <summary>
        /// Initializes a new instance of the <see cref="MdWriter"/> class, opening a stream to the
        /// file at the specified path.
        /// </summary>
        /// <param name="path">The full path to the output file, including file extension.</param>
        /// <param name="append">
        /// If true, output is appended to the file's existing contents; otherwise, the file is
        /// overwritten.
        /// </param>
        public MdWriter(string path, bool append = false) {
            stream = new StreamWriter(path, append);
        }

        #region IDisposable

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting
        /// unmanaged resources.
        /// </summary>
        public void Dispose() {
            if (stream != null) {
                stream.Dispose();
                stream = null;
            }
        }

        #endregion

        /// <summary>
        /// Closes the stream to the output file.
        /// </summary>
        public void Close() {
            if (stream != null) {
                stream.Close();
                stream = null;
            }
        }

        /// <summary>
        /// Writes the provided output to the file. Optional styling and formatting is applied using
        /// the specified <see cref="MdStyle"/> and <see cref="MdFormat"/>.
        /// </summary>
        /// <param name="output">The output to write.</param>
        /// <param name="style">The optional Markdown style to apply.</param>
        /// <param name="format">The optional Markdown format to apply.</param>
        public void Write(object output, MdStyle style = MdStyle.None,
                          MdFormat format = MdFormat.None) {
            string text = MdText.StyleAndFormat(output, style, format);
            stream.Write(MdText.Cleanse(text));
        }

        /// <summary>
        /// Writes the provided output to the file, followed by a Markdown paragraph break to
        /// terminate the line and start a new paragraph. Optional styling and formatting is applied
        /// using the specified <see cref="MdStyle"/> and <see cref="MdFormat"/>.
        /// </summary>
        /// <param name="output">The output to write.</param>
        /// <param name="style">The optional Markdown style to apply.</param>
        /// <param name="format">The optional Markdown format to apply.</param>
        public void WriteLine(object output, MdStyle style = MdStyle.None,
                              MdFormat format = MdFormat.None) {
            string text = MdText.StyleAndFormat(output, style, format);
            stream.Write(MdText.Cleanse(text) + MdText.ParagraphBreak);
        }

        /// <summary>
        /// Writes the provided output to the file, followed by a Markdown line break to terminate
        /// the line but not start a new paragraph. Optional styling and formatting is applied using
        /// the specified <see cref="MdStyle"/> and <see cref="MdFormat"/>.
        /// </summary>
        /// <param name="output">The output to write.</param>
        /// <param name="style">The optional Markdown style to apply.</param>
        /// <param name="format">The optional Markdown format to apply.</param>
        public void WriteLineSingle(object output, MdStyle style = MdStyle.None,
                                    MdFormat format = MdFormat.None) {
            string text = MdText.StyleAndFormat(output, style, format);
            stream.Write(MdText.Cleanse(text) + MdText.LineBreak);
        }

        /// <summary>
        /// Writes the provided output to the file using the
        /// <see cref="MdFormat.UnorderedListItem"/> format, followed by a Markdown paragraph break
        /// to terminate the list item. Optional styling is applied using the specified
        /// <see cref="MdStyle"/>.
        /// </summary>
        /// <param name="output">The output to write.</param>
        /// <param name="listIndent">
        /// The optional indent of the list item (0 adds no indent, 1 adds a single indentation to
        /// create a sublist, etc). Negative values are ignored.
        /// </param>
        /// <param name="style">The optional Markdown style to apply.</param>
        public void WriteUnorderedListItem(object output, int listIndent = 0,
                                           MdStyle style = MdStyle.None) {
            string text = MdText.StyleAndFormat(output, style, MdFormat.UnorderedListItem);
            text = MdText.Indent(text, listIndent);
            stream.Write(MdText.Cleanse(text) + MdText.ParagraphBreak);
        }

        /// <summary>
        /// Writes the provided output to the file using the <see cref="MdFormat.OrderedListItem"/>
        /// format, followed by a Markdown paragraph break to terminate the list item. Optional
        /// styling is applied using the specified <see cref="MdStyle"/>.
        /// </summary>
        /// <param name="output">The output to write.</param>
        /// <param name="itemNumber">
        /// The optional item number of the list item. Does not affect parsed Markdown output or the
        /// list order, only the raw text.
        /// </param>
        /// <param name="listIndent">
        /// The optional indent of the list item (0 adds no indent, 1 adds a single indentation to
        /// create a sublist, etc). Negative values are ignored.
        /// </param>
        /// <param name="style">The optional Markdown style to apply.</param>
        public void WriteOrderedListItem(object output, int itemNumber = 1, int listIndent = 0,
                                         MdStyle style = MdStyle.None) {
            string text = MdText.StyleAndFormat(output, style, MdFormat.OrderedListItem);
            //replace the list item number supplied by MdText with the number provided
            if (itemNumber != MdText.DefaultListItemNumber) {
                text = itemNumber + text.Substring(1);
            }
            text = MdText.Indent(text, listIndent);
            stream.Write(MdText.Cleanse(text) + MdText.ParagraphBreak);
        }
    }
}