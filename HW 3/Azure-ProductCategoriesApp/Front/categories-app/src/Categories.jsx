import React, { useState, useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { getCategories, getProductsByCategoryId } from "./store/reducer";

export function Categories() {
    const categories = useSelector((state) => state.products.categories);
    const products = useSelector((state) => state.products.products);
    const dispatch = useDispatch();

    useEffect(() => {
        dispatch(getCategories());
    }, [dispatch]);

    const handleCategoryChange = async (categoryId) => {
        dispatch(getProductsByCategoryId(categoryId));
    };

    return (
        <div>
            <select onChange={(e) => handleCategoryChange(e.target.value)}>
                <option value="">Select a category</option>
                {Array.isArray(categories) ? (
                    categories.map((category) => (
                        <option key={category.productCategoryId} value={category.productCategoryId}>
                            {category.name}
                        </option>
                    ))
                ) : (
                    <option disabled>Loading...</option>
                )}
            </select>

            <div>
                <h2>Products</h2>
                {Array.isArray(products) && products.length > 0 ? (
                    products.map((product) => (
                        <div key={product.productId}>
                            <p>{product.name}</p>
                        </div>
                    ))
                ) : (
                    <p>No products.</p>
                )}
            </div>
        </div>
    );
}
