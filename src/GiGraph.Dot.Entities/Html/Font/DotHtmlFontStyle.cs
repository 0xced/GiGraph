using System;
using System.Linq;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Html.Attributes.Factories;
using GiGraph.Dot.Entities.Html.Text;
using GiGraph.Dot.Output.EnumHelpers;
using GiGraph.Dot.Types.Fonts;

namespace GiGraph.Dot.Entities.Html.Font
{
    /// <summary>
    ///     An HTML font style element.
    /// </summary>
    public abstract class DotHtmlFontStyle : DotHtmlElement
    {
        protected DotHtmlFontStyle(string tagName)
            : base(tagName, new DotAttributeCollection(DotHtmlAttributeFactory.Instance))
        {
        }

        protected DotHtmlFontStyle(string tagName, DotAttributeCollection attributes)
            : base(tagName, attributes)
        {
        }

        protected virtual void AppendText(string text)
        {
            Children.Add(new DotHtmlText(text));
        }

        /// <summary>
        ///     Embeds the text in appropriate HTML tags based on the specified font style.
        /// </summary>
        /// <param name="text">
        ///     The text to embed in font style elements.
        /// </param>
        /// <param name="style">
        ///     The style to apply to the text.
        /// </param>
        public static DotHtmlEntity StyleText(string text, DotFontStyles style)
        {
            return StyleEntity(new DotHtmlText(text), style);
        }

        /// <summary>
        ///     Embeds the entity in appropriate HTML tags based on the specified font style.
        /// </summary>
        /// <param name="entity">
        ///     The entity to embed in font style elements. Only text and table elements are supported. See
        ///     <see href="https://graphviz.org/doc/info/shapes.html#html">
        ///         grammar
        ///     </see>
        ///     for more details.
        /// </param>
        /// <param name="style">
        ///     The style to apply to the text.
        /// </param>
        public static DotHtmlEntity StyleEntity(DotHtmlEntity entity, DotFontStyles style)
        {
            return (DotHtmlEntity) StyleEntity((IDotHtmlEntity) entity, style);
        }

        /// <summary>
        ///     Embeds the entity in appropriate HTML tags based on the specified font style.
        /// </summary>
        /// <param name="entity">
        ///     The entity to embed in font style elements. Only text and table elements are supported (including collections of those). See
        ///     <see href="https://graphviz.org/doc/info/shapes.html#html">
        ///         grammar
        ///     </see>
        ///     for more details.
        /// </param>
        /// <param name="style">
        ///     The style to apply to the text.
        /// </param>
        public static IDotHtmlEntity StyleEntity(IDotHtmlEntity entity, DotFontStyles style)
        {
            DotHtmlFontStyle rootElement = null;
            DotHtmlFontStyle nestedElement = null;

            var metadata = new DotEnumMetadata(style.GetType());
            foreach (var styleFlag in metadata.GetSetFlags(style).Cast<DotFontStyles>())
            {
                DotHtmlFontStyle styleElement = styleFlag switch
                {
                    DotFontStyles.Bold => new DotHtmlBold(),
                    DotFontStyles.Italic => new DotHtmlItalic(),
                    DotFontStyles.Underline => new DotHtmlUnderline(),
                    DotFontStyles.Overline => new DotHtmlOverline(),
                    DotFontStyles.Subscript => new DotHtmlSubscript(),
                    DotFontStyles.Superscript => new DotHtmlSuperscript(),
                    _ => throw new ArgumentOutOfRangeException(nameof(style), styleFlag, "Invalid font style flag")
                };

                nestedElement?.Children.Add(styleElement);
                nestedElement = styleElement;
                rootElement ??= nestedElement;
            }

            nestedElement?.Children.Add(entity);
            return rootElement ?? entity;
        }
    }
}