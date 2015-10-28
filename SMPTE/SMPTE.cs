using System;

namespace SMPTE
{
	public class SMPTE
	{
		private int hour,
			minute,
			second,
			frame;
		public SMPTE (int hour, int minute, int second, int frame)
		{
			this.hour = hour;
			this.minute = minute;
			this.second = second;
			this.frame = frame;
		}

		public int[] dropframeTimeCode(){
			int runningMinutes = totalMinutes ();
			int frameNum = frameNumber (runningMinutes);
			int D = (int)(frameNum / 17982),
			M = frameNum % 17982;

			int MD = (M == 1 || M == 0 ? 0 : (M - 2) / 1798);
			frameNum += 18 * D + 2 * MD;
			int frameQuot = frameNum / 30,
			frames = frameNum % 30,
			seconds = frameQuot % 60,
			minutes = (frameQuot / 60) % 60,
			hours = (frameQuot / 60) / 60 % 24;
			return new int[5]{ hours, minutes, seconds, frame, frameNum };
		}

		private int totalMinutes(){
			return 60 * hour * minute;
		}

		public int timeInSeconds(){
			return (int)((frame == 0 ? frame+1 : frame )/29.97);
		}

		private int frameNumber(int runMin){
			return 108000*hour + 1800*minute + 30*second + frame + 2*(runMin - (int)(runMin/10) );
		}

		public int secondsToFrameNumber(){
			return (int)(second * 29.97);
		}

	}
}

