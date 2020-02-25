public class Main {
    private static final float LOW_PRECISION = 0.05f;
    private static final float HIGH_PRECISION = 0.01f;

    public static void main(String[] args) {
        float end = 10f;
        float y0 = 1.0f;
        float step = Main.HIGH_PRECISION;
        int rank = 2;
        int n = (int)(end / step);
        float[] listOfY = new float[n];
        listOfY[0] = y0;

        for (int i = 1; i <= rank; i++) {
            float y = listOfY[i - 1];
            listOfY[i] = y + step * f(y, step * i);
        }

        for (int i = rank; i < n; i++) {
            float r1 = listOfY[i - 1];
            float r2 = listOfY[i - 2];
            float predict = (step * f(step * i, listOfY[i - 1] + step * f(step * i, listOfY[i - 1])));
            listOfY[i] = (4.f / 3.f * r1) - (1.f/3.f * r2) + (2.f/3.f * step) * predict;
        }

        for (int i = 0; i < listOfY.length; i++) {
            System.out.println("Y = " + listOfY[i]);
        }
    }

    public static float f(float x, float y) {
        return (1.8f * y) + (0.3f * (float)Math.pow(x,2));
    }
}
