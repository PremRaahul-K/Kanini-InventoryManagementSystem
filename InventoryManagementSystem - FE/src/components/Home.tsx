import React from "react";
import { Link } from "react-router-dom";
import Inventory from "./Inventory";
import { Routes, Route } from "react-router-dom";
import ProductList from "./ProductList";
import AddProductForm from "./AddProductForm";
import "tailwindcss/tailwind.css";

import { Fragment } from "react";
import { Popover, Transition } from "@headlessui/react";

const products = [
  {
    name: "Add Product",
    description: "You can add a product from here",
    to: "/add-product",
  },
  {
    name: "Products",
    description: "View all the list of products here",
    to: "/product-list",
  },
];
const Home: React.FC = () => {
  return (
    <div>
      <header className="bg-white">
        <nav
          className="mx-auto flex max-w-7xl items-center justify-between p-6 lg:px-8"
          aria-label="Global"
        >
          <div className="flex lg:flex-1">
            <Link to="" className="-m-1.5 p-1.5">
              <h1 className="text-xl font-bold font-sans text-cyan-950 ">
                Inventory Management System
              </h1>
            </Link>
          </div>
          <Popover.Group className="lg:flex lg:gap-x-12">
            <Popover className="relative">
              <Popover.Button className="flex items-center gap-x-1 text-sm font-semibold leading-6 text-gray-900">
                Inventory
              </Popover.Button>

              <Transition
                as={Fragment}
                enter="transition ease-out duration-200"
                enterFrom="opacity-0 translate-y-1"
                enterTo="opacity-100 translate-y-0"
                leave="transition ease-in duration-150"
                leaveFrom="opacity-100 translate-y-0"
                leaveTo="opacity-0 translate-y-1"
              >
                <Popover.Panel className="absolute -left-8 top-full z-10 mt-3 w-screen max-w-md overflow-hidden rounded-3xl bg-white shadow-lg ring-1 ring-gray-900/5">
                  <div className="p-4">
                    {products.map((item) => (
                      <div
                        key={item.name}
                        className="group relative flex items-center gap-x-6 rounded-lg p-4 text-sm leading-6 hover:bg-gray-50"
                      >
                        <div className="flex-auto">
                          <Link
                            to={item.to}
                            className="block font-semibold text-gray-900"
                          >
                            {item.name}
                            <span className="absolute inset-0" />
                          </Link>
                          <p className="mt-1 text-gray-600">
                            {item.description}
                          </p>
                        </div>
                      </div>
                    ))}
                  </div>
                </Popover.Panel>
              </Transition>
            </Popover>

            <a className="text-sm font-semibold leading-6 text-gray-900">
              Feedback
            </a>
            <a className="text-sm font-semibold leading-6 text-gray-900">
              Orders
            </a>
          </Popover.Group>
        </nav>
      </header>
      <div>
        <Routes>
          <Route path={"/"} element={<Inventory />} />
          <Route path={"/product-list"} element={<ProductList />} />
          <Route path={"/add-product"} element={<AddProductForm />} />
        </Routes>
      </div>
    </div>
  );
};

export default Home;
