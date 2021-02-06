import numpy as np
import matplotlib.pyplot as plt

class LinearRegression:

    def __init__(self, learning_rate=0.001, epochs=1000):
        self.learning_rate = learning_rate
        self.epochs = epochs
        self.weights = None
        self.bias = None

    def fit(self, X, y):
        n_samples, n_features = X.shape

        # init parameters
        self.weights = np.zeros(n_features)
        self.bias = 0

        # gradient descent
        for _ in range(self.epochs):
            y_predicted = np.dot(X, self.weights) + self.bias
            # compute gradients
            dw = (1 / n_samples) * np.dot(X.T, (y_predicted - y))
            db = (1 / n_samples) * np.sum(y_predicted - y)

            # update parameters
            self.weights -= self.learning_rate * dw
            self.bias -= self.learning_rate * db
 

    def predict(self, X):
        y_approximated = np.dot(X, self.weights) + self.bias
        return y_approximated

    def mean_squared_error(self, y_true, y_pred):
        return np.mean((y_true - y_pred)**2)

# test
from sklearn import datasets
from sklearn.model_selection import train_test_split

X, y = datasets.make_regression(n_samples=100, n_features=1, noise=20, random_state=4)
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=1234)


fig = plt.figure(figsize=(8,6))
plt.scatter(X[:, 0], y, color = "b", marker = "o", s = 30) 
plt.show()

regressor = LinearRegression(learning_rate=0.01, epochs=1000)
regressor.fit(X_train, y_train)
predictions = regressor.predict(X_test)
    
mse = regressor.mean_squared_error(y_test, predictions)
print("MSE:", mse)

y_pred_line = regressor.predict(X)

plt.figure(figsize=(8, 6))
plt.scatter(X[:, 0], y, color = "b", marker = "o", s = 30) 
plt.plot(X, y_pred_line)
plt.show()