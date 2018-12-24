using Amazon;
using Amazon.ElasticTranscoder;
using Amazon.ElasticTranscoder.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ElasticTranscoderListJobsByPipelineOperation : Operation
    {
        public override string Name => "ListJobsByPipeline";

        public override string Description => "The ListJobsByPipeline operation gets a list of the jobs currently in a pipeline. Elastic Transcoder returns all of the jobs currently in the specified pipeline. The response body contains one element for each job that satisfies the search criteria.";
 
        public override string RequestURI => "/2012-09-25/jobsByPipeline/{PipelineId}";

        public override string Method => "GET";

        public override string ServiceName => "ElasticTranscoder";

        public override string ServiceID => "Elastic Transcoder";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonElasticTranscoderClient client = new AmazonElasticTranscoderClient(creds, region);
            ListJobsByPipelineResponse resp = new ListJobsByPipelineResponse();
            do
            {
                ListJobsByPipelineRequest req = new ListJobsByPipelineRequest
                {
                    PageToken = resp.NextPageToken,
                    &lt;nil&gt; = maxItems
                };
                resp = client.ListJobsByPipeline(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.Jobs)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextPageToken));
        }
    }
}