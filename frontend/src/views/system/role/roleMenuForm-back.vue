<template>
  <a-modal
    title="授权菜单"
    :width="600"
    :visible="visible"
    :confirmLoading="confirmLoading"
    @ok="handleSubmit"
    @cancel="handleCancel"
  >
    <a-spin :spinning="formLoading">
      <a-form :form="form">
        <a-form-item label="菜单权限" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-tree
            v-model="checkedKeys"
            multiple
            checkable
            :auto-expand-parent="autoExpandParent"
            :expanded-keys="expandedKeys"
            :tree-data="menuTreeData"
            :selected-keys="selectedKeys"
            :replaceFields="replaceFields"
            @expand="onExpand"
            @check="onCheck"
          />
        </a-form-item>
      </a-form>
    </a-spin>
  </a-modal>
</template>

<script>
import { SysMenuTreeForGrant } from '@/api/modular/system/menuManage'
import { sysRoleOwnMenu, sysRoleGrantMenu } from '@/api/modular/system/roleManage'

export default {
  data() {
    return {
      labelCol: {
        style: {
          'padding-right': '20px',
        },
        xs: {
          span: 24,
        },
        sm: {
          span: 5,
        },
      },
      wrapperCol: {
        xs: {
          span: 24,
        },
        sm: {
          span: 15,
        },
      },
      menuTreeData: [],
      expandedKeys: [],
      checkedKeys: [],
      visible: false,
      confirmLoading: false,
      formLoading: true,
      autoExpandParent: true,
      selectedKeys: [],
      subValues: [],
      roleEntity: [],
      replaceFields: {
        key: 'id',
      },
      form: this.$form.createForm(this),
      commitKeys: [],
      leastChild: [],
    }
  },
  methods: {
    // 初始化方法
    async roleMenu(record) {
      this.formLoading = true
      this.roleEntity = record
      this.visible = true
      this.getMenuTree()
    },
    /**
     * 获取菜单列表
     */
    getMenuTree() {
      SysMenuTreeForGrant().then((res) => {
        if (res.success) {
          this.menuTreeData = res.data
          this.getLeastChild(res.data)
          // 默认展开目录级
          this.menuTreeData.forEach((item) => {
            this.expandedKeys.push(item.id)
          })
          this.expandedMenuKeys(this.roleEntity)
        }
      })
    },
    getLeastChild(data) {
      data.forEach((item) => {
        this.pushLeastChild(item)
      })
    },
    pushLeastChild(e) {
      if (e.children.length > 0) {
        this.getLeastChild(e.children)
        return
      }
      this.leastChild.push(e.id)
    },
    /**
     * 此角色已有菜单权限
     */
    expandedMenuKeys(record) {
      sysRoleOwnMenu({
        id: record.id,
      }).then((res) => {
        if (res.success) {
          this.pickCheckedKeys(res.data)
          this.commitKeys = res.data
        }
        this.formLoading = false
      })
    },
    pickCheckedKeys(data) {
      data.forEach((item) => {
        if (this.leastChild.includes(item)) {
          this.checkedKeys.push(item)
        }
      })
    },
    onExpand(expandedKeys) {
      this.expandedKeys = expandedKeys
      this.autoExpandParent = false
    },
    onCheck(checkedKeys, event) {
      this.checkedKeys = checkedKeys
      this.commitKeys = checkedKeys.concat(event.halfCheckedKeys)
    },
    handleSubmit() {
      const {
        form: { validateFields },
      } = this
      this.confirmLoading = true
      validateFields((errors, values) => {
        if (!errors) {
          sysRoleGrantMenu({
            id: this.roleEntity.id,
            grantMenuIdList: this.commitKeys,
          })
            .then((res) => {
              if (res.success) {
                this.$message.success('授权成功')
                this.confirmLoading = false
                this.$emit('ok', values)
                this.handleCancel()
              } else {
                this.$message.error('授权失败：' + res.message)
              }
            })
            .finally((res) => {
              this.confirmLoading = false
            })
        } else {
          this.confirmLoading = false
        }
      })
    },
    handleCancel() {
      // 清空已选择的
      this.checkedKeys = []
      // 清空已展开的
      this.expandedKeys = []
      this.visible = false
    },
  },
}
</script>
