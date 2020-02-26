def f(x):
    return (1/2)*(25/x+x)

iteration = 0
a = 1
b = 4
epsilon = 0.01

while abs(b - a) > epsilon:
    iteration += 1
    c = (a + b) / 2
    if (f(a) * f(c) > 0):
        a = c
    else:
        b = c
    print(str(iteration) + ' ' + str(abs(b-a)) + ' ' + str(c))

print('X: ' + str(c)) 
print('Число Итераций: ' + str(iteration))
print('Параметр сходимости: ' + str((b - a) / iteration))
