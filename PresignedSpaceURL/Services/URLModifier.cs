using Amazon.S3;
using Amazon.S3.Model;
using System;

namespace PresignedSpaceURL.Services
{
    public class URLModifier
    {
        public static string MakeUrlPresigned()
        {
            string accessKey = "Write your access key here";
            string secretKey = "write your secret key here";
            string serviceUrl = "Write you s3 base endpoints";
            string bucket = "write bucket name";
            string key = "write file path with name"; // audio/song.mp3

            AmazonS3Config config = new AmazonS3Config();
            config.ServiceURL = serviceUrl;
            AmazonS3Client s3Client = new AmazonS3Client(
                    accessKey,
                    secretKey,
                    config
                    );

            GetPreSignedUrlRequest request = new GetPreSignedUrlRequest
            {
                BucketName = bucket,
                Key = key,
                Expires = DateTime.Now.AddMinutes(1)
            };

            string url = s3Client.GetPreSignedURL(request); // this will return a url with access time with it
            return url;



            #region bucket list view
            //var response = await s3Client.ListBucketsAsync(); this will list current bucket list

            // List all objects
            //ListObjectsRequest listRequest = new ListObjectsRequest
            //{
            //    BucketName =bucket,
            //};
            //ListObjectsResponse listResponse;
            //do
            //{
            //    // Get a list of objects
            //    listResponse = await s3Client.ListObjectsAsync(listRequest);
            //    foreach (S3Object obj in listResponse.S3Objects)
            //    {
            //        Console.WriteLine("Object - " + obj.Key);
            //        Console.WriteLine(" Size - " + obj.Size);
            //        Console.WriteLine(" LastModified - " + obj.LastModified);
            //        Console.WriteLine(" Storage class - " + obj.StorageClass);
            //    }

            //    // Set the marker property
            //    listRequest.Marker = listResponse.NextMarker;
            //} while (listResponse.IsTruncated);


            #endregion
        }


    }
}
