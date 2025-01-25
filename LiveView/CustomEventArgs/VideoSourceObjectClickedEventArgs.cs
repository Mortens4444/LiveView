using LiveView.Dto;

namespace LiveView.CustomEventArgs
{
    public class VideoSourceObjectClickedEventArgs
    {
        public VideoSource VideoSource { get; private set; }

        public VideoSourceObjectClickedEventArgs(VideoSource videoSource)
        {
            VideoSource = videoSource;
        }
    }
}
