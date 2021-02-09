// Storage Controller
const StorageController = (function () {
    return {
        storeProduct: function (product) {
            let products;
            if (localStorage.getItem('products') === null) {
                products = [];
                products.push(product);
            } else {
                products = JSON.parse(localStorage.getItem('products'));
                products.push(product);
            }
            console.log(products);
            localStorage.setItem('products', JSON.stringify(products));
        },
        getProducts: function () {
            let products;
            if (localStorage.getItem('products') == null) {
                products = [];
            } else {
                products = JSON.parse(localStorage.getItem('products'));
            }
            console.log(products);
            return products;
        },
        updateProduct: function (product) {
            let products = JSON.parse(localStorage.getItem('products'));

            products.forEach((prd, index) => {
                if (product.id == prd.id) {
                    products.splice(index, 1, product);
                }
            });
            localStorage.setItem('products', JSON.stringify(products));
        },
        deleteProduct: function (id) {
            let products = JSON.parse(localStorage.getItem('products'));

            products.forEach((prd, index) => {
                if (id == prd.id) {
                    products.splice(index, 1);
                }
            });
            localStorage.setItem('products', JSON.stringify(products));
        }
    }
})();
// Product Controller
const ProductController = (function () {
    // private
    const Product = function (id, name, price) {
        this.id = id;
        this.name = name;
        this.price = price;
    }
    const data = {
        products: StorageController.getProducts(),
        selectedProduct: null,
        totalPrice: 0
    };

    // public
    return {
        getProducts: function () {
            return data.products;
        },
        getData: function () {
            return data;
        },
        addProduct: function (name, price) {
            let id = data.products.length > 0 ? data.products[data.products.length - 1].id + 1 : 0;

            const newProduct = new Product(id, name, parseFloat(price));
            data.products.push(newProduct);
            return newProduct;
        },
        updateProduct: function (name, price) {
            let product = null;
            data.products.forEach(item => {
                if (item.id == data.selectedProduct.id) {
                    item.name = name;
                    item.price = parseFloat(price);
                    product = item;
                }
            });
            return product;
        },
        deleteProduct: function (product) {
            data.products.forEach((prd, index) => {
                if (prd.id == product.id) {
                    data.products.splice(index, 1);
                }
            });
        },
        getTotal: function () {
            let total = 0;
            data.products.forEach(product => {
                total += parseFloat(product.price);
            });
            data.totalPrice = total;
            return data.totalPrice;
        },
        getProductById: function (id) {
            let product = null;
            data.products.forEach(item => {
                if (item.id == id) {
                    product = item;
                }
            });
            return product;
        },
        setCurrentProduct: function (product) {
            data.selectedProduct = product;
        },
        getCurrentProduct: function () {
            return data.selectedProduct;
        }
    }
})();

// UI Controller
const UIController = (function () {

    const selectors = {
        productList: '#item-list',
        addButton: '#btnAdd',
        updateButton: '#btnUpdate',
        cancelButton: '#btnCancel',
        deleteButton: '#btnDelete',
        productName: '#productName',
        productPrice: '#productPrice',
        totalTL: '#total-tl',
        productListItems: '#item-list tr',
        totalDolar: '#total-dolar',
        alertBox: '#alert-box'
    };

    // public
    return {
        showProductList: function (products) {
            let html = '';
            products.forEach(product => {
                html += `               
                    <tr>
                        <td>${product.id}</td>
                        <td>${product.name}</td>
                        <td>${product.price} $</td>
                        <td class="text-right">
                            <i class="far fa-edit edit-product"></i>
                        </td>
                    </tr>
                    `;
            });
            document.querySelector(selectors.productList).innerHTML = html;
        },
        getSelectors: function () {
            return selectors;
        },
        addProductToList: function (product) {
            let item = `               
                    <tr>
                        <td>${product.id}</td>
                        <td>${product.name}</td>
                        <td>${product.price} $</td>
                        <td class="text-right">
                            <i class="far fa-edit edit-product"></i>
                        </td>
                        </td>
                    </tr>
                    `;

            document.querySelector(selectors.productList).innerHTML += item;
        },
        updateProduct: function (product) {
            let updatedItem = null;

            let items = document.querySelectorAll(selectors.productListItems);
            items.forEach(item => {
                if (item.classList.contains('bg-warning')) {
                    item.children[1].textContent = product.name;
                    item.children[2].textContent = parseFloat(product.price) + '$';
                    updatedItem = item;
                }
            });
            return updatedItem;
        },
        deleteProduct: function () {
            let items = document.querySelectorAll(selectors.productListItems);
            items.forEach(item => {
                if (item.classList.contains('bg-warning')) {
                    item.remove();
                }
            });
        },
        clearInputs: function () {
            document.querySelector(selectors.productName).value = '';
            document.querySelector(selectors.productPrice).value = '';
        },
        clearWarnings: function () {
            const items = document.querySelectorAll(selectors.productListItems);
            items.forEach(item => {
                if (item.classList.contains('bg-warning')) {
                    item.classList.remove('bg-warning');
                }
            });
        },
        showAlert: function (className, text, ms = 1000) {
            setTimeout(() => {
                document.querySelector(selectors.alertBox).classList += className;
                document.querySelector(selectors.alertBox).innerHTML = text;
            }, ms);
        },
        showTotal: function (total, exchangeRate) {
            document.querySelector(selectors.totalDolar).textContent = total;
            document.querySelector(selectors.totalTL).textContent = total * exchangeRate;
        },
        addProductToForm: function () {
            const selectedProduct = ProductController.getCurrentProduct();
            document.querySelector(selectors.productName).value = selectedProduct.name;
            document.querySelector(selectors.productPrice).value = selectedProduct.price;
        },
        addingState: function (item) {
            UIController.clearWarnings();
            UIController.clearInputs();
            document.querySelector(selectors.addButton).style.display = 'inline';
            document.querySelector(selectors.updateButton).style.display = 'none';
            document.querySelector(selectors.cancelButton).style.display = 'none';
            document.querySelector(selectors.deleteButton).style.display = 'none';
        },
        editState: function (tr) {
            tr.classList.add('bg-warning');
            document.querySelector(selectors.addButton).style.display = 'none';
            document.querySelector(selectors.updateButton).style.display = 'inline';
            document.querySelector(selectors.cancelButton).style.display = 'inline';
            document.querySelector(selectors.deleteButton).style.display = 'inline';
        }
    }
})();

// App Controller
const App = (function (ProductController, UIController, StorageController) {

    const UISelectors = UIController.getSelectors();

    // Load event listeners
    const loadEventListeners = function () {
        // add product event
        document.querySelector(UISelectors.addButton).addEventListener('click', addProductButtonSubmit);
        // edit product click
        document.querySelector(UISelectors.productList).addEventListener('click', editProductClick);
        // edit product submit
        document.querySelector(UISelectors.updateButton).addEventListener('click', editProductSubmit);
        // cancel load event listener
        document.querySelector(UISelectors.cancelButton).addEventListener('click', cancelUpdate);
        // delete load event listener
        document.querySelector(UISelectors.deleteButton).addEventListener('click', deleteProductSubmit);
    }

    const addProductButtonSubmit = function (e) {

        const productName = document.querySelector(UISelectors.productName).value;
        const productPrice = document.querySelector(UISelectors.productPrice).value;


        if (productName !== '' && productPrice !== '') {
            // Add Product
            const newProduct = ProductController.addProduct(productName, productPrice);

            // Add Product to list
            UIController.addProductToList(newProduct);

            // add product to ls
            StorageController.storeProduct(newProduct);

            // get total
            const total = ProductController.getTotal();
            // show total 
            const exchangeRate = 7;
            UIController.showTotal(total, exchangeRate);

            // clear inputs
            UIController.clearInputs();


        }


        console.log(productName, productPrice);
        e.preventDefault();
    }
    const editProductClick = function (e) {
        if (e.target.classList.contains('edit-product')) {
            const id = e.target.parentNode.previousElementSibling.previousElementSibling.previousElementSibling.textContent;
            // get selected
            const product = ProductController.getProductById(id);

            // set current product
            ProductController.setCurrentProduct(product);
            console.log(product);

            UIController.clearWarnings();

            // add product infos to ui
            UIController.addProductToForm();
            UIController.editState(e.target.parentNode.parentNode);
        }
        e.preventDefault();
    }
    const editProductSubmit = function (e) {

        const productName = document.querySelector(UISelectors.productName).value;
        const productPrice = document.querySelector(UISelectors.productPrice).value;

        if (productName !== '' && productPrice !== '') {
            // update product
            const updatedProduct = ProductController.updateProduct(productName, productPrice);

            let item = UIController.updateProduct(updatedProduct);

            // update storage
            StorageController.updateProduct(updatedProduct);

            // get total
            const total = ProductController.getTotal();
            // show total 
            const exchangeRate = 7;
            UIController.showTotal(total, exchangeRate);


            UIController.addingState();
        }
        e.preventDefault();
    }
    const deleteProductSubmit = function (e) {

        const selectedProduct = ProductController.getCurrentProduct();

        // delete product
        ProductController.deleteProduct(selectedProduct);
        console.log(selectedProduct);

        // delete ui 
        UIController.deleteProduct();

        const total = ProductController.getTotal();

        UIController.showTotal(total);

        // delete storage
        StorageController.deleteProduct(selectedProduct.id);

        UIController.addingState();

        e.preventDefault();
    }
    const cancelUpdate = function (e) {
        UIController.addingState();
        UIController.clearWarnings();
        e.preventDefault();
    }

    return {
        init: function () {
            console.log('app starting...');
            UIController.addingState();
            const products = ProductController.getProducts();
            console.log(products);

            UIController.showProductList(products);

            // load event listeners
            loadEventListeners();
        }
    }

})(ProductController, UIController, StorageController);

App.init();