using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace SMPTE
{
	[Activity (Label = "SMPTE", MainLauncher = true)]
	public class MainActivity : Activity
	{
		

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);

			// the dew is done here
			EditText HourIn = FindViewById<EditText> (Resource.Id.hourIn),
			MinIn = FindViewById<EditText> (Resource.Id.minIn),
			SecIn = FindViewById<EditText> (Resource.Id.secIn),
			FrameIn = FindViewById<EditText> (Resource.Id.frameIn);
			Button calcButton = FindViewById<Button> (Resource.Id.calc);

			calcButton.Click += (object sender, EventArgs e) => {
				SMPTE dftc = new SMPTE(int.Parse(HourIn.Text), int.Parse(MinIn.Text), int.Parse(SecIn.Text), int.Parse(FrameIn.Text) );
				int[] output = dftc.dropframeTimeCode();
				EditText HourO = FindViewById<EditText> (Resource.Id.hourIn),
				MinO = FindViewById<EditText> (Resource.Id.minIn),
				SecO = FindViewById<EditText> (Resource.Id.secIn),
				FrameO = FindViewById<EditText> (Resource.Id.frameIn);
				HourO.Text = output[0]+"";
				MinO.Text = output[1]+"";
				SecO.Text = output[2]+"";
				FrameO.Text = output[4]+"";
			};

		}
	}
}


