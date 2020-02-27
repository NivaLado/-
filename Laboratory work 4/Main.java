public class Main {
    private static final float LOW_PRECISION = 0.05f;
    private static final float HIGH_PRECISION = 0.01f;

    public static void main(String[] args) {
        float end = 10f;
        float y0 = 1.0f;
        float step = Main.HIGH_PRECISION;
        int rank = 2;
        int n = (int) (end / step);
        float[] listOfY = new float[n];
        listOfY[0] = y0;

        int innerCount = 0;
        float y1 = y0 + step * f(y0);  // Euler Prediction
        listOfY[1] = y1;
        float y2;//= y1 + step * f(y1); // Euler Prediction

        for (int i = 2; i < n; i++) {
            y2 = y1 + step * f(y1);
        for (int j = 0; j < 10; j++ ) {
            y2 = ((4.f / 3.f) * y1) - ((1.f / 3.f) * y0) + (step * (2.f / 3.f) * f(y2));
        }
            listOfY[i] = y2;
            y0 = y1;
            y1 = y2;


        }
        System.out.println("count: " + innerCount);
        for (int j = 0; j < listOfY.length; j++) {
            float X = (j * step);
            float real = _f(1.8f, 0.3f, 1f, X);
            System.out.println((Math.abs(listOfY[j] - real)));
        }
    }

    public static float f(float y) {
        return (1.8f * y) - (0.3f * (float) Math.pow(y, 2));
    }

    public static float _f(float a, float b, float y0, float t) {
        float at = a * t;
        float epow = (float) Math.pow(Math.E, at);
        return (a * y0 * epow) / (a + b * y0 * (epow - 1));
    }
}

