using Amazon;
using Amazon.CloudDirectory;
using Amazon.CloudDirectory.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class CloudDirectoryListAppliedSchemaArnsOperation : Operation
    {
        public override string Name => "ListAppliedSchemaArns";

        public override string Description => "Lists schema major versions applied to a directory. If SchemaArn is provided, lists the minor version.";
 
        public override string RequestURI => "/amazonclouddirectory/2017-01-11/schema/applied";

        public override string Method => "POST";

        public override string ServiceName => "CloudDirectory";

        public override string ServiceID => "CloudDirectory";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCloudDirectoryClient client = new AmazonCloudDirectoryClient(creds, region);
            ListAppliedSchemaArnsResponse resp = new ListAppliedSchemaArnsResponse();
            do
            {
                ListAppliedSchemaArnsRequest req = new ListAppliedSchemaArnsRequest
                {
                    NextToken = resp.NextToken,
                    MaxResults = maxItems
                };
                resp = client.ListAppliedSchemaArns(req);
                CheckError(resp.HttpStatusCode, "200");                

                foreach (var obj in resp.&lt;nil&gt;)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}