using Amazon;
using Amazon.StorageGateway;
using Amazon.StorageGateway.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class StorageGatewayDescribeTapesOperation : Operation
    {
        public override string Name => "DescribeTapes";

        public override string Description => "Returns a description of the specified Amazon Resource Name (ARN) of virtual tapes. If a TapeARN is not specified, returns a description of all virtual tapes associated with the specified gateway. This operation is only supported in the tape gateway type.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "StorageGateway";

        public override string ServiceID => "Storage Gateway";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonStorageGatewayClient client = new AmazonStorageGatewayClient(creds, region);
            DescribeTapesOutput resp = new DescribeTapesOutput();
            do
            {
                DescribeTapesInput req = new DescribeTapesInput
                {
                    Marker = resp.Marker,
                    Limit = maxItems
                };
                resp = client.DescribeTapes(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.Tapes)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}