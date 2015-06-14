using System;
using UIKit;
using System.Collections.Generic;
using Foundation;

namespace DynamicRowHeightDemo
{
    public class DynamicTableViewSource : UITableViewSource
    {
        private const string WERTHER = "Eine wunderbare Heiterkeit hat meine ganze Seele eingenommen, gleich den süßen Frühlingsmorgen, die ich mit ganzem Herzen genieße. Ich bin allein und freue mich meines Lebens in dieser Gegend, die für solche Seelen geschaffen ist wie die meine. Ich bin so glücklich, mein Bester, so ganz in dem Gefühle von ruhigem Dasein versunken, daß meine Kunst darunter leidet. Ich könnte jetzt nicht zeichnen, nicht einen Strich, und bin nie ein größerer Maler gewesen als in diesen Augenblicken. Wenn das liebe Tal um mich dampft, und die hohe Sonne an der Oberfläche der undurchdringlichen Finsternis meines Waldes ruht, und nur einzelne Strahlen sich in das innere Heiligtum stehlen, ich dann im hohen Grase am fallenden Bache liege, und näher an der Erde tausend mannigfaltige Gräschen mir merkwürdig werden; wenn ich das Wimmeln der kleinen Welt zwischen Halmen, die unzähligen, unergründlichen Gestalten der Würmchen, der Mückchen näher an meinem Herzen fühle, und fühle die Gegenwart des Allmächtigen, der uns nach seinem Bilde schuf, das Wehen des Alliebenden, der uns in ewiger Wonne schwebend trägt und erhält; mein Freund!";

        private readonly List<KeyValuePair<string, string>> _textFragments;

        public DynamicTableViewSource()
        {
            _textFragments = new List<KeyValuePair<string, string>>();

            var random = new Random();

            for (int i = 0; i < 15; i++)
            {
                string title = WERTHER.Substring(0, random.Next(200));
                string text = WERTHER.Substring(0, random.Next(WERTHER.Length));

                _textFragments.Add(new KeyValuePair<string, string>(title, text));
            }
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return 1;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _textFragments.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (DynamicCell)tableView.DequeueReusableCell("TextFragmentCell");

            KeyValuePair<string, string> textFragment = _textFragments[indexPath.Row];

            cell.SetTitle(textFragment.Key);
            cell.SetText(textFragment.Value);

            return cell;
        }
    }
}

