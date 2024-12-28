public class Recursion {

    public void FooRec(int[] nums, int index, int sum, int target, ref int ans)
    {
        if(index < 0)
        {
            if(sum == target)
                ans++;
            
            return;
        }

        FooRec(nums, index-1, sum + nums[index], target, ref ans);
        FooRec(nums, index-1, sum - nums[index], target, ref ans);

        return;
    }

    public int FindTargetSumWays(int[] nums, int target) {
        
        int n = nums.Length;
        int sum = 0, ans = 0;
        
        FooRec(nums, n-1, sum, target, ref ans);

        return ans;
    }
}


public class MemoizationUsingDict {

    public int FooRec(int[] nums, int index, int sum, int target, Dictionary<(int, int), int> memo)
    {
        if(index < 0)
        {
            if(sum == target)
                return 1;
            
            return 0;
        }

        var key = (index, sum);
        
        if (memo.ContainsKey(key))
            return memo[key];

        int plus = FooRec(nums, index-1, sum + nums[index], target, memo);
        int minus = FooRec(nums, index-1, sum - nums[index], target, memo);

        memo[key] = plus + minus;
        
        return memo[key];
    }

    public int FindTargetSumWays(int[] nums, int target) {
        
        int n = nums.Length;
        int sum = 0;

        Dictionary<(int, int), int> memo = new Dictionary<(int, int), int>();
        
        return FooRec(nums, n-1, sum, target, memo);
    }
}


public class MemoizationUsing2DArray {

    public int FooRec(int[] nums, int index, int sum, int target, int offset, int[,] memo)
    {
        if(index < 0)
        {
            if(sum == target)
                return 1;
            
            return 0;
        }

        int mappedSum = sum + offset;
        
        if(memo[index, mappedSum] != -1)
            return memo[index, mappedSum];

        int plus = FooRec(nums, index-1, sum + nums[index], target, offset, memo);
        int minus = FooRec(nums, index-1, sum - nums[index], target, offset, memo);

        memo[index, mappedSum] = plus + minus;
        
        return memo[index, mappedSum];
    }

    public int FindTargetSumWays(int[] nums, int target) {
        
        int n = nums.Length;
        int sum = 0, totalSum = 0;

        //first calculate total sum
        foreach(var ele in nums)
            totalSum += ele;
        
        int[,] memo = new int[n, 2*totalSum + 1];
        int offset = totalSum;

        //initialize memo table
        for(int i=0; i<n; i++)
        {
            for (int j = 0; j < 2 * totalSum + 1; j++)
                memo[i,j] = -1;
        }
        
        return FooRec(nums, n-1, sum, target, offset, memo);
    }
}