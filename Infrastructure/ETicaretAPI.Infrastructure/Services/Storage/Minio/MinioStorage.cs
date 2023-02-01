using GOAL.Application.Abstractions.Storage;
using GOAL.Application.Abstractions.Storage.Minio;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Minio;
using Minio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOAL.Infrastructure.Services.Storage.Minio
{
    public class MinioStorage : Storage, IMinioStorage
    {
        
        MinioClient _minioClient;

        public MinioStorage(IConfiguration configuration)
        {
           _minioClient = new MinioClient()
                    .WithEndpoint(configuration["Storage:Minio:EndPoint"])
                    .WithCredentials(configuration["Storage:Minio:AccessKey "],configuration["Storage:Minio:SecretKey"])
                    .WithSSL()
                    .Build();
        }

        public async Task DeleteAsync(string pathOrContainerName, string fileName)
        {
            await _minioClient.RemoveObjectAsync(pathOrContainerName, fileName);
        }

        public  List<string> GetFiles(string pathOrContainerName)
        {
            bool isFound = _minioClient.BucketExistsAsync(pathOrContainerName).Result;
            if (isFound)
            {
                var listArgs = new ListObjectsArgs().WithBucket(pathOrContainerName);
                var result = _minioClient.ListObjectsAsync(listArgs).ToList();
                return result as List<string>;
            }
            else
            {
                throw new Exception("Bucket not found");
            }

            return new List<string> { };
        }

        public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files)
        {
            throw new NotImplementedException();
        }

        bool IStorage.HasFile(string pathOrContainerName, string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
