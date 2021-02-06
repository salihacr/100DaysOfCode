from scipy.spatial import distance

def euclidean_distance(a, b):
    return distance.euclidean(a, b)


class KNN():
    def fit(self, X_Train, Y_Train):
        self.X_Train = X_Train
        self.Y_Train = Y_Train
    
    def predict(self, X_Test):
        predictions = []

        for row in X_Test:
            label = self.closest(row)
            predictions.append(label)
        
        return predictions
    
    def closest(self, row):
        best_distance = euclidean_distance(row, self.X_Train[0])
        best_index = 0
        for i in range(1, len(self.X_Train)):
            dist = euclidean_distance(row, self.X_Train[i])
            if dist < best_distance:
                best_distance = dist
                best_index = i

        return self.Y_Train[best_index]

# test
from sklearn.datasets import load_iris

iris = load_iris()

X = iris.data
y = iris.target

# train test split
from sklearn.model_selection import train_test_split
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size = .5)

# create model
from sklearn.neighbors import KNeighborsClassifier

knn = KNeighborsClassifier(n_neighbors=5)

knn.fit(X_train, y_train)

# make prediction
preds = knn.predict(X_test)

# get accuracy
from sklearn.metrics import accuracy_score
print("sklearn knn : ", accuracy_score(y_test, preds))


my_knn = KNN()

my_knn.fit(X_train, y_train)
my_preds =my_knn.predict(X_test)

# get accuracy
from sklearn.metrics import accuracy_score
print("our knn : ", accuracy_score(y_test, my_preds))