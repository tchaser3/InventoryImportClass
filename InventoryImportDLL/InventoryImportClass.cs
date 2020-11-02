/* Title:           Inventory Import Class
 * Date:            10-29-2020
 * Author:          Terry Holmes
 * 
 * Description:     This is the class for the inventory import */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace InventoryImportDLL
{
    public class InventoryImportClass
    {
        //setting up the classes
        EventLogClass TheEventLogclass = new EventLogClass();

        InventoryImportDataSet aInventoryImportDataSet;
        InventoryImportDataSetTableAdapters.inventoryimportTableAdapter aInventoryImportTableAdapter;

        InsertInventoryImportEntryTableAdapters.QueriesTableAdapter aInsertInventoryImportTableAdapter;

        FindInventoryImportByWarehouseIDDataSet aFindInventoryImportByWarehouseIDDataSet;
        FindInventoryImportByWarehouseIDDataSetTableAdapters.FindInventoryImportByWarehouseIDTableAdapter aFindInventoryImportByWarehouseIDTableAdapter;

        RemoveInventoryImportEntryTableAdapters.QueriesTableAdapter aRemoveInventoryImportTableAdapter;

        public bool RemoveInventoryImport(int intWarehouseID, DateTime datStartDate, DateTime datEndDate)
        {
            bool blnFatalError = false;

            try
            {
                aRemoveInventoryImportTableAdapter = new RemoveInventoryImportEntryTableAdapters.QueriesTableAdapter();
                aRemoveInventoryImportTableAdapter.RemoveInventoryImport(intWarehouseID, datStartDate, datEndDate);
            }
            catch (Exception Ex)
            {
                TheEventLogclass.InsertEventLogEntry(DateTime.Now, "Inventory Import Class // Remove Inventory Import " + Ex.Message);
            }

            return blnFatalError;
        }
        public FindInventoryImportByWarehouseIDDataSet FindInventoryImportByWarehouseID(int intWarehouseID, DateTime datStartDate, DateTime datEndDate)
        {
            try
            {
                aFindInventoryImportByWarehouseIDDataSet = new FindInventoryImportByWarehouseIDDataSet();
                aFindInventoryImportByWarehouseIDTableAdapter = new FindInventoryImportByWarehouseIDDataSetTableAdapters.FindInventoryImportByWarehouseIDTableAdapter();
                aFindInventoryImportByWarehouseIDTableAdapter.Fill(aFindInventoryImportByWarehouseIDDataSet.FindInventoryImportByWarehouseID, intWarehouseID, datStartDate, datEndDate);
            }
            catch (Exception Ex)
            {
                TheEventLogclass.InsertEventLogEntry(DateTime.Now, "Inventory Import Class // Find Inventory Import By Warehouse ID " + Ex.Message);
            }

            return aFindInventoryImportByWarehouseIDDataSet;
        }
        public bool InsertInventoryImport(int intWarehouseID, int intPartID, string strInventoryLoctaion, int intOldCount, int intNewCount, DateTime datTransactionDate)
        {
            bool blnFatalError = false;

            try
            {
                aInsertInventoryImportTableAdapter = new InsertInventoryImportEntryTableAdapters.QueriesTableAdapter();
                aInsertInventoryImportTableAdapter.InsertInventoryImport(intWarehouseID,  intPartID, strInventoryLoctaion, intOldCount, intNewCount, datTransactionDate);
            }
            catch (Exception Ex)
            {
                TheEventLogclass.InsertEventLogEntry(DateTime.Now, "Inventory Import Class // Insert Inventory Import " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public InventoryImportDataSet GetInventoryImportInfo()
        {
            try
            {
                aInventoryImportDataSet = new InventoryImportDataSet();
                aInventoryImportTableAdapter = new InventoryImportDataSetTableAdapters.inventoryimportTableAdapter();
                aInventoryImportTableAdapter.Fill(aInventoryImportDataSet.inventoryimport);
            }
            catch (Exception Ex)
            {
                TheEventLogclass.InsertEventLogEntry(DateTime.Now, "Inventory Import Class // Get Inventory Import Info " + Ex.Message);
            }

            return aInventoryImportDataSet;
        }
        public void UpdateInventoryImport(InventoryImportDataSet aInventoryImportDataSet)
        {
            try
            {
                aInventoryImportTableAdapter = new InventoryImportDataSetTableAdapters.inventoryimportTableAdapter();
                aInventoryImportTableAdapter.Update(aInventoryImportDataSet.inventoryimport);
            }
            catch (Exception Ex)
            {
                TheEventLogclass.InsertEventLogEntry(DateTime.Now, "Inventory Import Class // Update Inventory Import DB " + Ex.Message);
            }
        }
    }
}
