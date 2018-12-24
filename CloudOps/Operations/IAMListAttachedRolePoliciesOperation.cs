using Amazon;
using Amazon.IAM;
using Amazon.IAM.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class IAMListAttachedRolePoliciesOperation : Operation
    {
        public override string Name => "ListAttachedRolePolicies";

        public override string Description => "Lists all managed policies that are attached to the specified IAM role. An IAM role can also have inline policies embedded with it. To list the inline policies for a role, use the ListRolePolicies API. For information about policies, see Managed Policies and Inline Policies in the IAM User Guide. You can paginate the results using the MaxItems and Marker parameters. You can use the PathPrefix parameter to limit the list of policies to only those matching the specified path prefix. If there are no policies attached to the specified role (or none that match the specified path prefix), the operation returns an empty list.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "IAM";

        public override string ServiceID => "IAM";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonIAMClient client = new AmazonIAMClient(creds, region);
            ListAttachedRolePoliciesResponse resp = new ListAttachedRolePoliciesResponse();
            do
            {
                ListAttachedRolePoliciesRequest req = new ListAttachedRolePoliciesRequest
                {
                    Marker = resp.Marker,
                    MaxItems = maxItems
                };
                resp = client.ListAttachedRolePolicies(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.AttachedPolicies)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}