using LiveView.Dto;

namespace LiveView.CustomEventArgs
{
    public class VideoSourceObjectClickedEventArgs
    {
        public VideoSourceDto VideoSource { get; private set; }

        public VideoSourceObjectClickedEventArgs(VideoSourceDto videoSource)
        {
            VideoSource = videoSource;
        }
    }
}
