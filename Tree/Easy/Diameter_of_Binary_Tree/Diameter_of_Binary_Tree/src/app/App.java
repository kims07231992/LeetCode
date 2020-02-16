package app;

public class App {
    public static void main(String[] args) throws Exception {
        run();
    }

    /// <summary>
    /// Time Complexity: O(N) where N is number of nodes
    /// Space Complexity: Balanced Tree Case => O(logN), Worst Tree Case => O(N)
    /// </summary>
    private static void run()
    {
        TreeNode root = new TreeNode(1);
        root.left = new TreeNode(2);
        root.right = new TreeNode(3);
        root.left.left = new TreeNode(4);
        root.left.right = new TreeNode(5);

        int result = diameterOfBinaryTree(root);
    }

    private static int maxDepth = 0;

    private static int diameterOfBinaryTree(TreeNode root) {
        traverse(root);
        
        return maxDepth;
    }
    
    private static int traverse(TreeNode node)
    {
        if (node == null)
            return 0;
        
        int leftDepth = traverse(node.left);
        int rightDepth = traverse(node.right);
        maxDepth = Math.max(maxDepth, leftDepth + rightDepth);
        
        return Math.max(leftDepth, rightDepth) + 1;
    }

    
    public static class TreeNode {
        int val;
        TreeNode left;
        TreeNode right;
        TreeNode(int x) { val = x; }
    }
}