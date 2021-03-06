using Amazon;
using Amazon.MediaConvert;
using Amazon.MediaConvert.Model;
using Amazon.Runtime;

namespace CloudOps.MediaConvert
{
    public class DescribeEndpointsOperation : Operation
    {
        public override string Name => "DescribeEndpoints";

        public override string Description => "Send an request with an empty body to the regional API endpoint to get your account API endpoint.";
 
        public override string RequestURI => "/2017-08-29/endpoints";

        public override string Method => "POST";

        public override string ServiceName => "MediaConvert";

        public override string ServiceID => "MediaConvert";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonMediaConvertConfig config = new AmazonMediaConvertConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonMediaConvertClient client = new AmazonMediaConvertClient(creds, config);
            
            DescribeEndpointsResponse resp = new DescribeEndpointsResponse();
            do
            {
                DescribeEndpointsRequest req = new DescribeEndpointsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.DescribeEndpoints(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Endpoints)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}