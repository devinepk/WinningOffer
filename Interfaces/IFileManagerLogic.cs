using System.Threading.Tasks;
using Azure.Storage.Blobs;
using LightningOffer.Models;
using Microsoft.AspNetCore.Http;

namespace LightningOffer.Controllers
{
    public interface IFileManagerLogic
    {

        Task Upload(IFormFile file);
    }

    public class FileManagerLogic : IFileManagerLogic
    {
        private readonly BlobServiceClient _blobServiceClient;
        public FileManagerLogic(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }
        public async Task Upload(IFormFile file)
        {
            var blobContainer = _blobServiceClient.GetBlobContainerClient("upload-preapproval-letter");

            var blobClient = blobContainer.GetBlobClient(file.FileName);

            await blobClient.UploadAsync(file.OpenReadStream());
        }
    }
}