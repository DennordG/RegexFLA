using System;
using System.Text;
using System.Text.RegularExpressions;
using Prism.Commands;

namespace RegexFLA.ViewModels
{
	public class MainWindowViewModel : AbstractViewModel
	{
		#region Properties
		private string _regexText;
		public string RegexText
		{
			get => _regexText;
			set => ChangeAndNotify(ref _regexText, value);
		}

		private string _lookupText;
		public string LookupText
		{
			get => _lookupText;
			set => ChangeAndNotify(ref _lookupText, value);
		}

		private string _matchText;
		public string MatchText
		{
			get => _matchText;
			set => ChangeAndNotify(ref _matchText, value);
		}

		public DelegateCommand SubmitCommand { get; set; }
		#endregion


		#region .ctor
		public MainWindowViewModel()
		{
			SubmitCommand = new DelegateCommand(Submit);
		}
		#endregion


		#region Private methods
		private void Submit()
		{
			try
			{
				var matches = Regex.Matches(LookupText, RegexText);
				if (matches.Count > 0)
				{
					var matchText = new StringBuilder();
					matchText.AppendLine($"{matches.Count} matches found:");

					foreach (Match match in matches)
					{
						matchText.AppendLine($"{match.Value} found at position {match.Index}");
					}

					MatchText = matchText.ToString();
				}
				else
				{
					MatchText = "No matches found.";
				}
			}
			catch (ArgumentException)
			{
				MatchText = "Invalid pattern sequence!";
			}
		}
		#endregion
	}
}
