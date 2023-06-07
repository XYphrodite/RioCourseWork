//using Emgu.CV.CvEnum;
//using Emgu.CV.Structure;
//using Emgu.CV;
//using System.Drawing;
//using VisioForge.Libs.Accord.Vision.Detection;
//using Emgu.CV.Face;
//using System.Text.RegularExpressions;

//namespace RioCourseWork.Services
//{
//    public class FaceRecognizer
//    {
//        private readonly IWebHostEnvironment webHostEnvironment;
//        #region Variables
//        int testid = 0;
//        private Capture videoCapture = null;
//        private Image<Bgr, Byte> currentFrame = null;
//        Mat frame = new Mat();
//        private bool facesDetectionEnabled = false;
        
//        Image<Bgr, Byte> faceResult = null;
//        List<Image<Gray, Byte>> TrainedFaces = new List<Image<Gray, byte>>();
//        List<int> PersonsLabes = new List<int>();

//        bool EnableSaveImage = false;
//        private bool isTrained = false;
//        EigenFaceRecognizer recognizer;
//        List<string> PersonsNames = new List<string>();

//        #endregion
//        Image<Gray, byte> grayFace = null;

//        public FaceRecognizer(IWebHostEnvironment webHostEnvironment)
//        {
//            this.webHostEnvironment = webHostEnvironment;
//        }

//        public async Task Add(Bitmap bmp)
//        {
//            var path_ = Path.Combine(webHostEnvironment.ContentRootPath, "haarcascade_frontalface_default.xml");
//            CascadeClassifier faceCascade = new CascadeClassifier(path_);

//            grayFace = BitmapExtension.ToImage<Gray, byte>(bmp);
//            currentFrame = BitmapExtension.ToImage<Bgr, Byte>(bmp);
//            Mat grayImage = new Mat();
//            CvInvoke.CvtColor(currentFrame, grayImage, ColorConversion.Bgr2Gray);
//            //Enhance the image to get better result
//            CvInvoke.EqualizeHist(grayImage, grayImage);

//            Rectangle[] faces = faceCascade.DetectMultiScale(grayImage, 1.1, 3, Size.Empty, Size.Empty);

//            //If faces detected
//            if (faces.Length > 0)
//            {
//                foreach (var face in faces)
//                {
//                    //Step 3: Add Person 
//                    //Assign the face to the picture Box face picDetected
//                    Image<Bgr, Byte> resultImage = currentFrame;
//                    resultImage.ROI = face;

//                    //We will create a directory if does not exists!
//                    string path = Directory.GetCurrentDirectory() + @"\TrainedImages";
//                    if (!Directory.Exists(path))
//                        Directory.CreateDirectory(path);
//                    //we will save 10 images with delay a second for each image 
//                    //to avoid hang GUI we will create a new task
//                    await Task.Factory.StartNew(() => {
//                        for (int i = 0; i < 10; i++)
//                        {
//                            resultImage.Resize(200, 200, Inter.Cubic).Save(path + @"\" + new Random().NextInt64().ToString() + "_" + DateTime.Now.ToString("dd-mm-yyyy-hh-mm-ss") + ".jpg");
//                        }
//                    });
//                    // Step 5: Recognize the face 
//                    if (isTrained)
//                    {
//                        Image<Gray, Byte> grayFaceResult = resultImage.Convert<Gray, Byte>().Resize(200, 200, Inter.Cubic);
//                        CvInvoke.EqualizeHist(grayFaceResult, grayFaceResult);
//                        var result = recognizer.Predict(grayFaceResult);
//                        //Here results found known faces
//                        if (result.Label != -1 && result.Distance < 2000)
//                        {
//                            CvInvoke.PutText(currentFrame, PersonsNames[result.Label], new Point(face.X - 2, face.Y - 2),
//                                FontFace.HersheyComplex, 1.0, new Bgr(Color.Orange).MCvScalar);
//                            CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Green).MCvScalar, 2);
//                        }
//                        //here results did not found any know faces
//                        else
//                        {
//                            CvInvoke.PutText(currentFrame, "Unknown", new Point(face.X - 2, face.Y - 2),
//                                FontFace.HersheyComplex, 1.0, new Bgr(Color.Orange).MCvScalar);
//                            CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Red).MCvScalar, 2);

//                        }
//                    }
//                }
//            }
//        }
//    }
//}
