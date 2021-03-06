using System;
using System.Linq;
using System.Threading;
using FluentWebUITesting.Accessors;
using FluentWebUITesting.Controls;
using JetBrains.Annotations;
using WatiN.Core;

namespace FluentWebUITesting.Extensions
{
	public static class BrowserExtensions
	{
		public static ButtonWrapper ButtonWithVisibleText(this Browser browser, [NotNull] string text)
		{
			const string buttonWithLabel = "button with visible text '{0}'";
			return new ButtonWrapper(browser.Button(Find.ByValue(text).Or(Find.ByText(text))), String.Format(buttonWithLabel, text));
		}

		public static CheckBoxWrapper CheckBoxWithId(this Browser browser, [NotNull] string id)
		{
			const string checkBoxWithId = "checkbox with id '{0}'";
			var checkBox = browser.CheckBoxes.FirstOrDefault(x => x.Id == id) ?? browser.CheckBox(Find.ById(id));
			return new CheckBoxWrapper(checkBox, String.Format(checkBoxWithId, id));
		}

		public static CheckBoxWrapper CheckBoxWithIdAndValue(this Browser browser, [NotNull] string id, [NotNull] string value)
		{
			const string message = "checkbox with id '{0}' and value '{1}'";
			var checkBox = browser.CheckBoxes.FirstOrDefault(x => x.Id == id && x.GetAttributeValue("value") == value) ??
			               browser.CheckBox(Find.ById(id));
			return new CheckBoxWrapper(checkBox, String.Format(message, id, value));
		}

		public static DivWrapper DivWithId(this Browser browser, [NotNull] string id)
		{
			const string divWithId = "div with id '{0}'";
			return new DivWrapper(browser.Div(Find.ById(id)), String.Format(divWithId, id));
		}

		public static DropDownListWrapper DropDownListWithId(this Browser browser, [NotNull] string idOfList)
		{
			const string dropDownListWithId = "drop down list with id '{0}'";
			return new DropDownListWrapper(browser.SelectList(Find.ById(idOfList)),
			                               String.Format(dropDownListWithId, idOfList));
		}

		public static FileDownloadHandlerWrapper FileDownload(this Browser browser, Action action)
		{
			return new FileDownloadHandlerWrapper(browser, action);
		}
		
		public static DialogHandlerWrapper Dialog(this Browser browser, Action action)
		{
			return new DialogHandlerWrapper(browser, action);
		}

		public static LabelWrapper LabelWithId(this Browser browser, [NotNull] string id)
		{
			const string labelWithId = "label with id '{0}'";
			return new LabelWrapper(browser.Label(Find.ById(id)), String.Format(labelWithId, id));
		}

		public static LinkWrapper LinkWithId(this Browser browser, [NotNull] string id)
		{
			const string linkWithId = "link with id '{0}'";
			return new LinkWrapper(browser.Link(Find.ById(id)), String.Format(linkWithId, id));
		}

		public static LinkWrapper LinkWithVisibleText(this Browser browser, [NotNull] string text)
		{
			const string linkWithText = "link with visible text '{0}'";
			return new LinkWrapper(browser.Link(Find.ByText(text)), String.Format(linkWithText, text));
		}

		public static void Pause(this Browser browser, int milliseconds)
		{
			Thread.Sleep(milliseconds);
		}

		public static RadioButtonOptionWrapper RadioButtonOptionWithId(this Browser browser, [NotNull] string idOfOption)
		{
			const string radioButtonOptionWithId = "radio button option with id '{0}'";
			return new RadioButtonOptionWrapper(browser.RadioButton(Find.ById(idOfOption)),
			                                    String.Format(radioButtonOptionWithId, idOfOption));
		}

		public static SpanWrapper SpanWithId(this Browser browser, [NotNull] string id)
		{
			const string spanWithId = "span with id '{0}'";
			return new SpanWrapper(browser.Span(Find.ById(id)), String.Format(spanWithId, id));
		}

		public static TableWrapper TableWithId(this Browser browser, [NotNull] string id)
		{
			const string tableWithId = "table with id '{0}'";
			return new TableWrapper(browser.Table(Find.ById(id)), String.Format(tableWithId, id));
		}

		public static ReadOnlyText Text(this Browser browser)
		{
			return new ReadOnlyText("Page", browser.Text);
		}

		public static TextBoxWrapper TextBoxWithId(this Browser browser, [NotNull] string id)
		{
			const string textBoxWithId = "text box with id '{0}'";
			return new TextBoxWrapper(browser
			                          	.TextField(Find.ById(id)), String.Format(textBoxWithId, id));
		}
	}
}