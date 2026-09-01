using System.Globalization;

namespace DSA.Common;

public static class DFSandBFS 
{

    //DFS - depth first - explore a single path as deeply as possible before backtracking to explore alternative branches (recursiv sau stack)
    public static int[][] FloodFill(int[][] image, int sr, int sc, int color)
    {
        int initialColor = image[sr][sc];

        if (initialColor == color)
        {
            return image;
        }

        Fill(image, sr, sc, initialColor, color);

        return image;
    }

    private static void Fill(
        int[][] img,
        int row,
        int col,
        int initialColor,
        int newColor)
    {
        if (row < 0 ||
            row >= img.Length ||
            col < 0 ||
            col >= img[row].Length)
        {
            return;
        }

        if (img[row][col] != initialColor)
        {
            return;
        }

        img[row][col] = newColor;

        Fill(img, row + 1, col, initialColor, newColor);
        Fill(img, row - 1, col, initialColor, newColor);
        Fill(img, row, col + 1, initialColor, newColor);
        Fill(img, row, col - 1, initialColor, newColor);
    }

    //BFS - parcurgerea în lățime (Breadth-First) - se uita la toti vecinii inainte de a merge mai departe (queue)
    public static int[][] FIllWithQueue(int[][] image, int sr, int sc, int color)
    {
        Queue<(int,int)> values = new Queue<(int,int)>();

        int initalColor = image[sr][sc];

        if(initalColor == color)
            return image;

        image[sr][sc] = color;
        values.Enqueue((sr,sc));

        (int row, int col)[] directions =
        {
            (-1,0),
            (0,-1),
            (1,0),
            (0,1)
        };

        while(values.Count > 0)
        {
           var currentPoint = values.Dequeue();

            foreach(var direction in directions)
            {
                int nextRow = currentPoint.Item1 + direction.row;
                int nextCol = currentPoint.Item2 + direction.col;

                if(nextRow >= 0 && nextRow < image.Length && nextCol >= 0 && nextCol < image[nextRow].Length && image[nextRow][nextCol] == initalColor)
                {
                    image[nextRow][nextCol] = color;
                    values.Enqueue((nextRow, nextCol));
                }
            }
        }
        return image;
    }

    //NumberOfIslands - DFS
    public static int NumIslands(char[][] grid)
    {
        int numberOfIslands = 0;

        for(int i=0; i<grid.Length; i++)
        {
            for(int j=0; j<grid[i].Length; j++)
            {
                if(grid[i][j] == '1')
                {
                    numberOfIslands++;
                    MarkIsland(grid, i, j);
                }
                    
            }
        }

        return numberOfIslands;
    }

    public static void MarkIsland(char[][] grid, int i, int j)
    {
        Queue<(int,int)> values = new Queue<(int,int)>();

        grid[i][j] = '0';

        (int row, int col)[] directions =
        {
            (-1,0),
            (0,-1),
            (1,0),
            (0,1)
        };

        values.Enqueue((i,j));

        while(values.Count > 0)
        {
            var currentPosition = values.Dequeue();

            foreach(var direction in directions)
            {
                int nextRow = currentPosition.Item1 + direction.row;
                int nextCol = currentPosition.Item2 + direction.col;

                if(nextRow >= 0 && nextRow < grid.Length && nextCol >= 0 && nextCol < grid[nextRow].Length && grid[nextRow][nextCol] == '1')
                {
                    grid[nextRow][nextCol]= '0';
                    values.Enqueue((nextRow, nextCol));
                }
            }
        }

    }

    public class TreeNode
    {
        public int Val;
        public TreeNode? Left;
        public TreeNode? Right;

        public TreeNode(int val)
        {
            Val = val;
        }
    }

    //maximum depth of binary tree - DFS - recursiv
    public static int MaxDepth(TreeNode? root)
    {
        if(root == null)
            return 0;

        int leftDepth = MaxDepth(root.Left);
        int rightDepth = MaxDepth(root.Right);

        return 1 + Math.Max(leftDepth, rightDepth);
    }

    //binary tree level order traversal - BFS
    public static IList<IList<int>> LevelOrder(TreeNode? root)
    {
        Queue<TreeNode> queue = new Queue<TreeNode>();

        IList<IList<int>> result = new List<IList<int>>();

        if(root == null)
            return result;


        queue.Enqueue(root);

        while(queue.Count > 0)
        {
            int levelSize = queue.Count;
            var currentLevel = new List<int>();

            for(int i=0; i<levelSize; i++)
            {
                var currentPosition = queue.Dequeue();

                currentLevel.Add(currentPosition.Val);

                if(currentPosition.Left != null)
                {
                    queue.Enqueue(currentPosition.Left);
                }

                if(currentPosition.Right != null)
                {
                    queue.Enqueue(currentPosition.Right);
                }
            }   
            result.Add(currentLevel);         
        }

        return result;
    }
    
}

