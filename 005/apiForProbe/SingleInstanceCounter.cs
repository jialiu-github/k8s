public static class SingleInstanceCounter {
    private static int counter = 1;
    public static void Inc ()
    {
        counter++;
    }
    public static long Counter()
    {
        return counter;
    }
}