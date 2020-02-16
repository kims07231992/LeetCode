import java.util.*; 

class Solution {
    public static void main(String[] args) {
        run();
    }

    private static void run()
    {
        int[][] matrix = {
            {1,2,2,3,5},
            {3,2,3,4,4},
            {2,4,5,3,1},
            {6,7,1,4,5},
            {5,1,1,2,4}
        };
        List<List<Integer>> result = pacificAtlantic(matrix);
    }

    public static List<List<Integer>> pacificAtlantic(int[][] matrix) {
        List<List<Integer>> result = new ArrayList<List<Integer>>();
        if(matrix == null || matrix.length == 0 || matrix[0].length == 0){
            return result;
        }
        
        int m = matrix.length;
        int n = matrix[0].length;
        boolean[][] pacificVisited = new boolean[m][n];
        boolean[][] atlaticVisited = new boolean[m][n];
        for (int i = 0; i < m; i++) // vertical
        {
            Visit(matrix, pacificVisited, i, 0, Integer.MIN_VALUE);
            Visit(matrix, atlaticVisited, i, n - 1, Integer.MIN_VALUE);
        }
        
        for (int i = 0; i < n; i++) // horizontal
        {
            Visit(matrix, pacificVisited, 0, i, Integer.MIN_VALUE);
            Visit(matrix, atlaticVisited, m - 1, i, Integer.MIN_VALUE);
        }
        
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (pacificVisited[i][j] && atlaticVisited[i][j])
                {
                    List<Integer> list = new ArrayList<Integer>();
                    list.add(i);
                    list.add(j);
                    result.add(list);
                }
            }
        }
        
        return result;
    }
    
    private static void Visit(int[][] matrix, boolean[][] visited, int m, int n, int height)
    {
        if (m < 0 
            || m >= matrix.length 
            || n < 0 
            || n >= matrix[m].length
            || visited[m][n] 
            || height > matrix[m][n])
            return;
        
        visited[m][n] = true;
        Visit(matrix, visited, m, n + 1, matrix[m][n]);
        Visit(matrix, visited, m + 1, n, matrix[m][n]);
        Visit(matrix, visited, m, n - 1, matrix[m][n]);
        Visit(matrix, visited, m - 1, n, matrix[m][n]);
    }
}