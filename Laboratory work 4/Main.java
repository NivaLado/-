public class Main {
    private static final float LOW_PRECISION = 0.05f;
    private static final float HIGH_PRECISION = 0.01f;

    public static void main(String[] args) {
        float end = 1f;
        float y0 = 1.0f;
        float step = Main.HIGH_PRECISION;
        int rank = 2;
        int n = (int)(end / step);
        float[] listOfY = new float[n];
        listOfY[0] = y0;

        for (int i = 1; i <= rank; i++) {
            float y = listOfY[i - 1];
            listOfY[i] = y + step * f( step * i, y);
        }

        for (int i = rank; i < n; i++) {
            float y1 = listOfY[i - 1];
            float y2 = listOfY[i - 2];
            float predict = f(step * i, y1 + step * f(step * i, y1));
            listOfY[i] = ((4.f / 3.f) * y1) - ((1.f/3.f) * y2) + (step * (2.f/3.f) * predict);
        }

        for (int i = 0; i < listOfY.length; i++) {
            float X = (i * step);
            float real = _f(X, listOfY[i]);
            System.out.println("X = " +  X + " Y = " + listOfY[i] + " err: " + (Math.abs(listOfY[i] - real)));
        }
    }

    public static float f(float x, float y) {
        return (1.8f * y) - (0.3f * (float)Math.pow(y,2));
    }

    public static float _f(float x, float y) {
        float tmp = (float)Math.exp(1.8f * x);
        return 1.8f * y * tmp / (1.8f + 0.3f * y * (tmp - 1));
    }
}
