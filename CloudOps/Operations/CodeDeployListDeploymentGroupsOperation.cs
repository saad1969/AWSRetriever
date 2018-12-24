using Amazon;
using Amazon.CodeDeploy;
using Amazon.CodeDeploy.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class CodeDeployListDeploymentGroupsOperation : Operation
    {
        public override string Name => "ListDeploymentGroups";

        public override string Description => "Lists the deployment groups for an application registered with the applicable IAM user or AWS account.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "CodeDeploy";

        public override string ServiceID => "CodeDeploy";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCodeDeployClient client = new AmazonCodeDeployClient(creds, region);
            ListDeploymentGroupsOutput resp = new ListDeploymentGroupsOutput();
            do
            {
                ListDeploymentGroupsInput req = new ListDeploymentGroupsInput
                {
                    nextToken = resp.nextToken,
                    &lt;nil&gt; = maxItems
                };
                resp = client.ListDeploymentGroups(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.deploymentGroups)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.nextToken));
        }
    }
}