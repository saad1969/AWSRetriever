using Amazon;
using Amazon.ServiceCatalog;
using Amazon.ServiceCatalog.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ServiceCatalogListLaunchPathsOperation : Operation
    {
        public override string Name => "ListLaunchPaths";

        public override string Description => "Lists the paths to the specified product. A path is how the user has access to a specified product, and is necessary when provisioning a product. A path also determines the constraints put on the product.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ServiceCatalog";

        public override string ServiceID => "Service Catalog";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonServiceCatalogClient client = new AmazonServiceCatalogClient(creds, region);
            ListLaunchPathsOutput resp = new ListLaunchPathsOutput();
            do
            {
                ListLaunchPathsInput req = new ListLaunchPathsInput
                {
                    PageToken = resp.NextPageToken,
                    PageSize = maxItems
                };
                resp = client.ListLaunchPaths(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.&lt;nil&gt;)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextPageToken));
        }
    }
}