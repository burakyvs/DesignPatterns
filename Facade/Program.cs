using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            VideoConverter videoConverter = new VideoConverter(); // Facade class.

            VideoFile videoFile = new VideoFile("test.ogg");

            videoConverter.Convert(ref videoFile, ".mp4"); // Simplified conversion work in the facade class.

            Console.WriteLine(videoFile.GetFullName());
        }
    }

    // These are some of the classes of a complex third-party video conversion framework.
    // We can't control that code. Therefore can't simplify it.

    class VideoFile
    {
        public string FileName { get; private set; }
        public string Format { get; set; }

        public VideoFile(string filename)
        {
            FileName = filename.Substring(0, filename.IndexOf('.'));
            Format = filename.Substring(filename.IndexOf('.'));
        }

        public string GetFullName()
        {
            return FileName + Format;
        }

        public void ChangeFormat(CodecFactory sourceCodec, Codec destCodec, string newFormat)
        {
            Format = newFormat;
        }
    }


    public interface Codec
    {
        //...
    }
    class MPEG4CompressionCodec : Codec
    {
        public MPEG4CompressionCodec()
        {
            //...
        }
    }

    class OggCompressionCodec : Codec
    {
        public OggCompressionCodec()
        {
            //...
        }
    }

    class CodecFactory
    {
        public CodecFactory()
        {
            //...
        }
    }

    // Create a facade class to hide the complexibility.
    class VideoConverter
    {
        public void Convert(ref VideoFile videoFile, string newFormat)
        {
            CodecFactory sourceCodec = new CodecFactory();
            Codec destinationCodec;
            if (newFormat == "mp4")
            {
                destinationCodec = new MPEG4CompressionCodec();
            }
            else
            {
                destinationCodec = new OggCompressionCodec();
            }

            videoFile.ChangeFormat(sourceCodec, destinationCodec, newFormat);
        }
    }
}
