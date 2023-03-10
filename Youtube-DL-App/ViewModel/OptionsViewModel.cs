using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace Youtube_DL_App.ViewModel
{
    public class OptionsViewModel : ViewModelBase
    {
		private readonly List<string> audioFormatOptions = new()
		{
			"mp3",
			"wav"
		};

		private bool extractAudio;

		public List<string> AudioFormatOptions => this.audioFormatOptions;

		public bool ExtractAudio
		{
			get => this.extractAudio;
			set => this.Set(ref this.extractAudio, value);
		}
	}
}
