namespace Mtf.Enums.Image
{
    public enum ImageTransformMethod : byte
    {
        DifferenceEdgeDetector,
        HomogenityEdgeDetector,
        SobelEdgeDetector,
        InverseSobelEdgeDetector,
        EigCornerDetection,
        HarrisCornerDetection,
        ModifiedHarrisCornerDetection,
        Laplace_v1,
        Laplace_v2,
        RobertsEdgeDetector,
        CustomMethod
    }
}
